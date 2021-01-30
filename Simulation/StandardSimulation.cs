using MultiscaleModelling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MultiscaleModelling.Controllers;
using MultiscaleModelling.Models;
using MultiscaleModelling.Core;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Simulation
// Namespace declaration.
// Deklaracja przestrzeni nazw.
{
    class StandardSimulation : ISimulation
    // Declaring a class followed by a unique identifier.
    // Deklarowanie klasy, po którym następuje unikatowy identyfikator.
    {
        private Random _random;
        // Member access modifier. Private access is the least access level.
        // Modyfikator dostępu składowej. Dostęp prywatny to najmniejszy poziom dostępu.

        BitmapEngine _bitmapEngine;
        // Encapsulates a GDI + bitmap that consists of the pixel data of a graphic image and its attributes.
        // Hermetyzuje mapę bitową GDI+, która składa się z danych pikseli obrazu graficznego i jego atrybutów.
        InclusionsEngine _inclusionsEngine;
        SimulationEngine _simulationEngine;
        CAEngine _CAEngine;
        // In-Process and Out-of-Process Instantiations.
        // Instancje w trakcie i poza procesem.
        FileEngine _fileEngine;
        // This class provides an interface to all camera functions.
        // Ta klasa udostępnia interfejs wszystkich funkcji aparatu.

        IProcessable _processEngine;

        public StandardSimulation()
        // Public access allows you to access any variable and function from anywhere in your code.
        // Dostęp publiczny umożliwia uzyskiwanie dostępu do dowolnej zmiennej i funkcji z dowolnego miejsca w kodzie.
        {
            _random = new Random();
            _simulationEngine = new SimulationEngine(_random);
            // Simulation Engine service implementation.
            // Wdrożenie usługi Simulation Engine.
            _bitmapEngine = new BitmapEngine(_simulationEngine);
            // Initializes a new instance of the Bitmap class.
            // Inicjuje nowe wystąpienie klasy Bitmap.
            _inclusionsEngine = new InclusionsEngine(_random, _simulationEngine);
            _CAEngine = new CAEngine(_random, _simulationEngine);
            _fileEngine = new FileEngine(_simulationEngine);

        }


        public Bitmap GetBitmap()
        // Access modifier for types and type members. Public access is the highest level of access.
        // Modyfikator dostępu dla typów i elementów członkowskich typu. Dostęp publiczny to najwyższy poziom dostępu.
        {
            return _bitmapEngine.GetBitmap();
            // The statement ends execution of the method in which it occurs and returns control to the calling method.
            // Instrukcja kończy wykonywanie metody, w której występuje i zwraca kontrolę do metody wywołującej.
        }

        public void Initialize(Configuration config)
        // We use void as the return type of the method(or local function) to specify that the method does not return a value.
        // Używamy void jako zwracanego typu metody (lub funkcji lokalnej), aby określić, że metoda nie zwraca wartości.
        {
            _simulationEngine.Initialize(config);
            SetProcessEngine();
        }

        public void Restart()
        {
            _simulationEngine.Restart();
        }

        public void InitializeStep()
        {
            _processEngine.InitializeStep();
        }

        public bool IsMapEmpty()
        // bool - The keyword, is an alias for a System.Boolean of the .NET structure type that represents a boolean value which can be either true false.
        // bool - Słowo kluczowe, jest aliasem dla System.Boolean typu struktury .NET, który reprezentuje wartość logiczną, która może być albo true false.
        {
            return _simulationEngine.IsMapEmpty;
            // The statement ends execution of the method in which it occurs and returns control to the calling method.
            // Instrukcja kończy wykonywanie metody, w której występuje i zwraca kontrolę do metody wywołującej.
        }

        public void AddInclusions(ConfigurationInclusions config)
        {
            _inclusionsEngine.AddInclusions(config);
        }

        public void NextStep()
        {
            _processEngine.NextStep();
        }

        public void ExportToFile(FileTypeEnum type, string fileName)
        {
            _fileEngine.ExportToFile(type, fileName);
        }

        public void ImportFromFile(FileTypeEnum type, string fileName)
        {
            _fileEngine.ImportFromFile(type, fileName);
        }

        public bool IsEndSimulation()
        {
            return _simulationEngine.EndSimulation;
        }

        public void AddOrRemoveGrainsToSelectLis(int x, int y)
        {
            _simulationEngine.AddOrRemoveGrainsInSelectList(x, y);
        }

        public void StartGenerateSubstructure(Configuration config)
        {
            _simulationEngine.StartGenerateSubstructure(config);
            SetProcessEngine();
        }

        public Configuration GetConfiguration()
        {
            return _simulationEngine.Configuration;
        }

        public void RestartSelectedList()
        {
            _simulationEngine.RestartSelectedList();
        }

        public Bitmap GetBitmapGrainsSelection(bool visibility)
        // Gets or sets a value that indicates whether the control and all its child controls are displayed.
        // Pobiera lub ustawia wartość wskazującą, czy formant i wszystkie jego kontrolki podrzędne są wyświetlane.
        {
            return _bitmapEngine.GetBitmapGrainsSelection(visibility);
        }

        public void AddBoundariesForGrains(Configuration config)
        {
            _simulationEngine.AddBoundariesForGrains(config);
        }

        public void RemoveGrainsColors()
        {
            _simulationEngine.RemoveGrainsColors();
        }

        public float GetGBPercent()
        {
            return _simulationEngine.GetGBPercent();
        }

        public void CalculateEnergy()
        {
            _simulationEngine.CalculateEnergy();
        }

        public Bitmap GetEnergyBitmap()
        {
            return _bitmapEngine.GetEnergyBitmap();
        }


        private void SetProcessEngine()
        {
                _processEngine = _CAEngine;
            /* Using a conditional operator instead of an if-else statement can result in more concise code 
             * in cases where you need to conditionally compute a value.
             * Użycie operatora warunkowego zamiast instrukcji if-else może spowodować bardziej zwięzły kod 
             * w przypadkach, gdy konieczne jest warunkowe obliczenie wartości.
             */

        }


    }
}
