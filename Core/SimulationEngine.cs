using MultiscaleModelling.Controllers;
using MultiscaleModelling.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Core
{
    class SimulationEngine
    {

        private MapController _mapController;
        private Configuration _configuration;

        private Random _random;
        private List<Grain> _grains;
        private bool _endSimulation;
        private bool _isMapEmpty;
        private int _currentGrainId;
        private List<Grain> _selectedGrains;


        public MapController MapController { get { return _mapController; } set { _mapController = value; } }
        public Configuration Configuration { get { return _configuration; } set { _configuration = value; } }
        public bool EndSimulation { get { return _endSimulation; } set { _endSimulation = value; } }
        public bool IsMapEmpty { get { return _isMapEmpty; } set { _isMapEmpty = value; } }
        public List<Grain> SelectedGrains { get { return _selectedGrains; } set { _selectedGrains = value; } }
        public List<Grain> Grains { get { return _grains; } set { _grains = value; } }

        public SimulationEngine(Random random)
        {
            _random = random;
            _grains = new List<Grain>();
            _selectedGrains = new List<Grain>();
            _isMapEmpty = true;
            _currentGrainId = 100;
        }

        public void AddOrRemoveGrainsInSelectList(int x, int y)
        {
            var node = _mapController.GetNode(x, y);
            if (node.Id > 100)
            {
                if (!_selectedGrains.Any(k => k.Id == node.Id))
                {
                    _selectedGrains.Add(new Grain()
                    {
                        Color = node.Color,
                        Id = node.Id
                    });
                }
                else
                {
                    var toRemove = _selectedGrains.FirstOrDefault(k => k.Id == node.Id);
                    _selectedGrains.Remove(toRemove);
                }
            }
        }
        public void StartGenerateSubstructure(Configuration config)
        {
            _configuration = config;

            Grain newGrain = null;
            if (config.StructureTypeEnume == StructureTypeEnume.DualPhase)
            {
                newGrain = GetRandomGrain();
            }

            for (int x = 1; x <= _configuration.Width; x++)
            {
                for (int y = 1; y <= _configuration.Height; y++)
                {
                    var node = _mapController.GetNode(x, y);
                    if (_selectedGrains.Any(k => k.Id == node.Id))
                    {
                        if (newGrain == null)
                        {
                            node.Type = TypeEnum.OldGrain;
                            _mapController.SetNode(x, y, node);
                        }
                        else
                        {
                            _mapController.SetNode(x, y, new Node()
                            {
                                Color = newGrain.Color,
                                Id = newGrain.Id,
                                Type = TypeEnum.OldGrain,
                                X = x,
                                Y = y
                            });
                        }
                    }
                    else if (node.Type == TypeEnum.Inclusion || node.Type == TypeEnum.GrainBorder)
                    {
                        _mapController.SetNode(x, y, node);
                    }
                    else
                    {
                        _mapController.SetNode(x, y, _mapController.GetEmptyNode(x, y));
                    }
                }
            }
            _mapController.Commit();
            _endSimulation = false;
            _mapController.CopyMap();

            if (config.StructureTypeEnume == StructureTypeEnume.DualPhase)
            {
                _selectedGrains = new List<Grain>();
                _selectedGrains.Add(newGrain);
            }
        }
        public List<Node> GetListOfEdgesNodes()
        {
            List<Node> edgesNodes = new List<Node>();

            for (int x = 1; x <= _configuration.Width; x++)
            {
                for (int y = 1; y <= _configuration.Height; y++)
                {
                    var myNode = _mapController.GetNode(x, y);
                    var neighbourhood = _mapController.GetNeighbourhoods(x, y, NeighbourhoodEnum.Moore);
                    int otherGrainCount = neighbourhood.Count(k => k.Type == TypeEnum.Grain && k.Id != myNode.Id);

                    if (otherGrainCount != 0)
                        edgesNodes.Add(myNode);
                }
            }

            return edgesNodes;
        }
        public Grain GetRandomGrain()
        {
            int id = _currentGrainId++;
            Color color;
            bool isNewColor = false;
            do
            {
                color = Color.FromArgb(_random.Next(2, 254), _random.Next(2, 254), _random.Next(2, 254));
                isNewColor = !_grains.Any(k => k.Color.GetHashCode() == color.GetHashCode());
            } while (!isNewColor);


            return new Grain()
            {
                Id = id,
                Color = color
            };
        }
        public void EndSubstructureSimulation()
        {
            for (int x = 1; x <= _configuration.Width; x++)
            {
                for (int y = 1; y <= _configuration.Height; y++)
                {
                    var node = _mapController.GetNode(x, y);
                    if (node.Type == TypeEnum.OldGrain)
                        node.Type = TypeEnum.Grain;
                }
            }
        }
        public void GenerateListOfGrains()
        {
            _grains = new List<Grain>();

            for (int x = 1; x < _configuration.Width; x++)
            {
                for (int y = 1; y < _configuration.Height; y++)
                {
                    var node = _mapController.GetNode(x, y);
                    if ((node.Type == TypeEnum.Grain || node.Type == TypeEnum.OldGrain) && !_grains.Any(k => k.Id == node.Id))
                    {
                        _grains.Add(new Grain()
                        {
                            Id = node.Id,
                            Color = node.Color
                        });
                    }
                }
            }

            _currentGrainId = _grains.Max(k => k.Id);
            _currentGrainId++;
        }
        public void AddBoundariesForGrains(Configuration config)
        {
            var grainList = new List<Grain>();

            if (_selectedGrains.Any())
                grainList = _selectedGrains;
            else
                grainList = _grains;

            foreach (var grain in grainList)
            {
                AddBorderForGrain(grain, config.SizeOfGB);
            }
        }
        public void RemoveGrainsColors()
        {
            _mapController.CopyMap();
            for (int x = 1; x <= _configuration.Width; x++)
            {
                for (int y = 1; y <= _configuration.Height; y++)
                {
                    var node = _mapController.GetNode(x, y);
                    if (node.Type == TypeEnum.Grain)
                    {
                        var empty = _mapController.GetEmptyNode(x, y);
                        _mapController.SetNode(x, y, empty);
                    }
                }
            }
            _mapController.Commit();
        }
        public float GetGBPercent()
        {
            float GBNode = 0;
            float max = _configuration.Width * _configuration.Height;
            for (int x = 1; x < _configuration.Width; x++)
            {
                for (int y = 1; y < _configuration.Height; y++)
                {
                    var node = _mapController.GetNode(x, y);
                    if (node.Type == TypeEnum.GrainBorder)
                        GBNode++;
                }
            }
            return GBNode / max * 100;
        }
        public void CalculateEnergy()
        {
            var heighterEnergy = GetListOfEdgesNodes();
            if (heighterEnergy.Count == 0)
            {
                for (int x = 1; x <= _configuration.Width; x++)
                {
                    for (int y = 1; y <= _configuration.Height; y++)
                    {
                        var node = _mapController.GetNode(x, y);
                        if (node.Type == TypeEnum.Grain)
                            node.H = GetRandomEnergy(_configuration.BorderEnergy - _configuration.GrainEnergy, _configuration.BorderEnergy, 10);
                        else
                            node.H = 0;
                    }
                }
            }
            else
            {
                for (int x = 1; x <= _configuration.Width; x++)
                {
                    for (int y = 1; y <= _configuration.Height; y++)
                    {
                        var node = _mapController.GetNode(x, y);
                        var isMoreEnergy = heighterEnergy.Any(k => k.X == x && k.Y == y);
                        if (node.Type == TypeEnum.Grain)
                            node.H = isMoreEnergy ? GetRandomEnergy(_configuration.BorderEnergy, _configuration.BorderEnergy, 10) : GetRandomEnergy(_configuration.GrainEnergy, _configuration.BorderEnergy, 10);
                        else
                            node.H = 0;
                    }
                }
            }


        }
        public void RestartSelectedList()
        {
            _selectedGrains = new List<Grain>();
        }
        public void Restart()
        {
            _mapController = new MapController(_configuration.Width, _configuration.Height);
            _mapController.Commit();
            _endSimulation = false;
            _isMapEmpty = true;
            _selectedGrains.Clear();
        }
        public void Initialize(Configuration config)
        {
            if (_configuration == null || _configuration.Width != config.Width || _configuration.Width != config.Height)
            {
                _mapController = new MapController(config.Width, config.Height);
                _mapController.Commit();
            }
            else
            {
                _mapController.CopyMap();
            }
            _configuration = config;
            _isMapEmpty = false;
            _selectedGrains.Clear();
        }


        private void AddBorderForGrain(Grain grain, int size)
        {
            List<Node> grainNodes = new List<Node>();
            List<Node> grainNodesNew;
            for (int x = 1; x <= _configuration.Width; x++)
            {
                for (int y = 1; y <= _configuration.Height; y++)
                {
                    var node = _mapController.GetNode(x, y);
                    if (node.Id == grain.Id)
                        grainNodes.Add(node);
                }
            }

            while (size > 0)
            {
                grainNodesNew = new List<Node>();
                _mapController.CopyMap();
                foreach (var node in grainNodes)
                {
                    var neighbourhood = _mapController.GetNeighbourhoods(node.X, node.Y, NeighbourhoodEnum.Moore);
                    int otherGrainCount = neighbourhood.Count(k => (k.Type == TypeEnum.Grain || k.Type == TypeEnum.GrainBorder || k.Type == TypeEnum.Border) && k.Id != node.Id);
                    if (otherGrainCount != 0)
                    {
                        Node neNode = new Node()
                        {
                            Type = TypeEnum.GrainBorder,
                            Color = _mapController.GetGrainBorderColor(),
                            X = node.X,
                            Y = node.Y,
                            Id = 6,
                        };
                        _mapController.SetNode(node.X, node.Y, neNode);
                    }
                    else
                    {
                        grainNodesNew.Add(node);
                    }
                }
                grainNodes = grainNodesNew;
                _mapController.Commit();
                size--;
            }


        }
        private double GetRandomEnergy(double energy, double maxEnergy, int percet)
        {
            var rand = (double)(_random.Next(percet * 2) - percet) / 100.0;
            var newEnergy = energy + rand * energy;
            return newEnergy > maxEnergy ? maxEnergy : newEnergy;
        }

    }
}
