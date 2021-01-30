using MultiscaleModelling.Helpers;
using MultiscaleModelling.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Controllers
{
    public class MapController
    {
        private static Color _borderColor = Color.Black;
        private static Color _emptyColor = Color.White;
        private static Color _inclusionColor = Color.Black;
        private static Color _borderGraintColor = Color.Black;
        private static Color _recrystalizationColor = Color.Red;
        // The colors of the field and its elements.
        // Kolory pola i jego elementów.

        private int _width;
        private int _height;
        // Field size.
        // Rozmiar pola.

        private Map _previousMap;
        private Map _currentMap;
        // View of field.
        // Widok pola.

        public MapController()
        {

        }
        public MapController(int width, int height)
        {
            width+=2;
            height+=2;
            // Add border nodes.
            // Dodaj węzły graniczne.

            _width = width;
            _height = height;
            _currentMap = new Map(_width, _height);
            Commit();
            // Commits a database transaction.
            // Zatwierdza transakcję bazy danych.
        }

        public void Commit()
        // You can use void as a referent to declare a pointer to an unknown type.
        // Można użyć void jako typu referent, aby zadeklarować wskaźnik do nieznanego typu.
        {
            _previousMap = _currentMap;
            CreteNewMap();
        }

        public void CopyMap()
        {
            for (int x = 0; x < _width; x++)
            // The unary increment operator ++increments its operand by 1.The operand must be a variable, a Property access, or an indexer access.
            // Jednoargumentowy operator przyrostu ++ zwiększa jego operand o 1. Operand musi być zmienną, dostępem do Właściwości lub dostępem indeksatora .
            {
                for (int y = 0; y < _height; y++)
                {
                    _currentMap.SetNode(_previousMap.GetNode(x, y),x,y);
                    // SetNode is used to set a GetNode to access the node.
                    // SetNode służy do ustawiania a GetNode do uzyskiwania dostępu do węzła.
                }
            }
        }

        public void Rollback()
        {
            CreteNewMap();
        }

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        // return - the statement ends execution of the method in which it occurs and returns control to the calling method. It can also return an optional value.
        // return - instrukcja kończy wykonywanie metody, w której występuje i zwraca kontrolę do metody wywołującej. Może również zwrócić wartość opcjonalną.

        public Node GetNode (int x, int y)
        {
            return _previousMap.GetNode(x, y);
        }
        public List<Node> GetNeighbourhoods(int x, int y, NeighbourhoodEnum type, bool isFromCurrent = false)
        {
            switch (type)
            // Switch is a selection statement that selects a single switch to execute from a candidate list based on a pattern match with a Match expression.
            // Switch jest instrukcją wyboru, która wybiera pojedynczy przełącznik , który ma zostać wykonany z listy kandydatów na podstawie dopasowania wzorca z wyrażeniem Match.
            {
                case NeighbourhoodEnum.Moore:
                    return GetMooreNeighbourhoods(x,y, isFromCurrent);
                case NeighbourhoodEnum.VonNeumann:
                    return GetVonNeumannNeighbourhoods(x,y, isFromCurrent);
                case NeighbourhoodEnum.Cross:
                    return GetCrossNeighbourhoods(x, y, isFromCurrent);
            }
            return new List<Node>();
        }

        public void SetNode(int x, int y, Node node)
        {
            if(x >= 0 && y >= 0 && x < _width && y < _height)
                // && - operator logiczny.
                // && - logical operator.
                _currentMap.SetNode(node, x, y);
        }

        public Node GetCurrentNode (int x,int y)
        {
            if (x < _width && y < _height)
                return _currentMap.GetNode(x, y);
            return null;
        }

        public Bitmap GetBitmap()
        {
            Bitmap bitmap = new Bitmap(_width, _height);
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                // for - the statement executes a statement or a block of statements when the specified Boolean expression returns true.
                // for - instrukcja wykonuje instrukcję lub blok instrukcji, gdy określone wyrażenie logiczne zwraca wartość true.
                {
                    var node = _previousMap.GetNode(x, y);
                    bitmap.SetPixel(x, y, node.Color);
                }
            }
            return bitmap;
        }
        public Bitmap GetBitmapWithHiddenColors(List<int> ids)
        {
            Bitmap bitmap = new Bitmap(_width, _height);
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var node = _previousMap.GetNode(x, y);
                    // A common use for the var keyword is in a constructor call expression.Using the var program makes it possible to not repeat the type name in variable declaration and object instantiation.
                    // Typowym zastosowaniem var słowa kluczowego jest wyrażenie wywołania konstruktora. Użycie programu var umożliwia nie powtarzanie nazwy typu w deklaracji zmiennej i tworzeniu wystąpienia obiektu.

                    if (!ids.Contains(node.Id))
                        bitmap.SetPixel(x, y, _previousMap.GetNode(x, y).Color);
                    else
                        bitmap.SetPixel(x, y, _emptyColor);
                }
            }
            return bitmap;
        }

        private List<Color> GetEnergyColors(Color fColor, Color sColor,int size)
        {

            int rMax = fColor.R;
            int rMin = sColor.R;
            int gMax = fColor.G;
            int gMin = sColor.G;
            int bMax = fColor.B;
            int bMin = sColor.B;
            // Creates a new Color structure using the specified sRGB color channel values.
            // Tworzy nową Color strukturę przy użyciu określonych sRGB wartości kanału koloru.

            var colorList = new List<Color>();
            for (int i = 0; i < size; i++)
            {
                var rAverage = rMin + (int)((rMax - rMin) * i / size);
                var gAverage = gMin + (int)((gMax - gMin) * i / size);
                var bAverage = bMin + (int)((bMax - bMin) * i / size);
                colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }
            return colorList;
        }
        public Bitmap GetBitmapWithEnergyColors()
        {
            var energyColors = GetEnergyColors(Color.Green, Color.Blue,101);
            Bitmap bitmap = new Bitmap(_width, _height);
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var node = _previousMap.GetNode(x, y);
                    var energy = node.H / 7.0 * 100;
                    
                    if(node.Type == TypeEnum.Border)
                        bitmap.SetPixel(x, y, _previousMap.GetNode(x, y).Color);
                    else if (node.Type == TypeEnum.Recrystallization)
                        bitmap.SetPixel(x, y, _recrystalizationColor);
                    else
                        bitmap.SetPixel(x, y, energyColors[(int)energy]);
                }
            }
            return bitmap;
        }
        public void ImportFromFile(string name,FileTypeEnum type)
        {
            var mapper = GetColorMapper();
            switch (type)
            {
                case FileTypeEnum.Bmp:
                    _currentMap = FileHelper.ImportFromBmp(name, mapper);
                    break;
                case FileTypeEnum.Text:
                    _currentMap = FileHelper.ImportFromTxt(name, mapper);
                    break;
            }

            _width = _currentMap.Width;
            _height = _currentMap.Height;

            Commit();
        }
        public void ExportToFile(string name, FileTypeEnum type)
        {
            switch (type)
            {
                case FileTypeEnum.Bmp:
                    FileHelper.ExportToBmp(GetBitmap(),name);
                    break;
                case FileTypeEnum.Text:
                    FileHelper.ExportToTxt(_previousMap, name);
                    break;
            }
        }

        public Node GetEmptyNode(int x, int y)
        {
            return new Node()
            {
                Color = _emptyColor,
                Id = 0,
                Type = TypeEnum.Empty,
                X=x,
                Y=y
            };
        }
        public Node GetInclusionNode(int x, int y)
        {
            return new Node()
            {
                Color = _inclusionColor,
                Id = 3,
                Type = TypeEnum.Inclusion,
                X = x,
                Y = y
            };
        }

        public Color GetGrainBorderColor()
        {
            return _borderGraintColor;
        }

        private Dictionary<TypeEnum,Color> GetColorMapper()
        {
            var result = new Dictionary<TypeEnum,Color>();

            result.Add(TypeEnum.Border,_borderColor );
            result.Add(TypeEnum.Inclusion,_inclusionColor);
            result.Add(TypeEnum.Empty,_emptyColor);

            return result;
        }
        private void CreteNewMap()
        {
            _currentMap = new Map(_width, _height);
            CreateEmptyMap();
        }
        private void CreateEmptyMap()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    TypeEnum type = TypeEnum.Empty;
                    Color color = _emptyColor;
                    if (x == 0 || y == 0 || x == _width - 1 || y == _height - 1)
                    {
                        type = TypeEnum.Border;
                        color = _borderColor;
                    }
                    _currentMap.SetNode(new Node()
                    {
                        X = x,
                        Y = y,
                        Type = type,
                        Color= color
                    }, x, y);
                }
            }
        }


        private List<Node> GetMooreNeighbourhoods(int x, int y, bool isFromCurrent)
        {
            Map map = _previousMap;
            if (isFromCurrent)
                map = _currentMap;

            List<Node> neighbourhoods = new List<Node>();
            for(int k = -1; k <= 1; k++)
            {
                neighbourhoods.Add(map.GetNode(x + k, y + 1));
                neighbourhoods.Add(map.GetNode(x + k, y - 1));
                if(k != 0)
                {
                    neighbourhoods.Add(map.GetNode(x + k, y));
                }
            }

            return neighbourhoods;
        }
        private List<Node> GetVonNeumannNeighbourhoods(int x, int y, bool isFromCurrent)
        {
            Map map = _previousMap;
            if (isFromCurrent)
                map = _currentMap;

            List<Node> neighbourhoods = new List<Node>();

            neighbourhoods.Add(map.GetNode(x , y+1));
            neighbourhoods.Add(map.GetNode(x-1, y));
            neighbourhoods.Add(map.GetNode(x+1, y));
            neighbourhoods.Add(map.GetNode(x, y-1));

            return neighbourhoods;
        }
        private List<Node> GetCrossNeighbourhoods(int x, int y, bool isFromCurrent)
        {
            Map map = _previousMap;
            if (isFromCurrent)
                map = _currentMap;

            List<Node> neighbourhoods = new List<Node>();

            neighbourhoods.Add(map.GetNode(x-1, y + 1));
            neighbourhoods.Add(map.GetNode(x + 1, y+1));
            neighbourhoods.Add(map.GetNode(x - 1, y-1));
            neighbourhoods.Add(map.GetNode(x + 1, y- 1));

            return neighbourhoods;
        }
    }
}
