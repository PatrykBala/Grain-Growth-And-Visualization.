using MultiscaleModelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiscaleModelling.Interfaces;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Core
{
    class RecrystallizationEngine : IProcessable
    {
        private SimulationEngine _simulationEngine;
        private Random _random;
        private List<int> _nucleonsPerIteration;
        private List<Grain> _states;
        private int _maxIteration;
        private int _iteration;
        public RecrystallizationEngine(Random random, SimulationEngine simulationEngine)
        {
            _random = random;
            _simulationEngine = simulationEngine;
        }


        public void InitializeStep()
        {
            _maxIteration = _simulationEngine.Configuration.ConfigurationRecrystallization.Iterations;
            _simulationEngine.EndSimulation = false;
            _iteration = 0;
            _simulationEngine.CalculateEnergy();

            GenerateListOfStates();
            GenerateListOfNucleaonsPerIterations();
        }

        public void NextStep()
        {
            if(_iteration >= _maxIteration)
            {
                _simulationEngine.EndSimulation = true;
                return;
            }

            SeedNewNode(_nucleonsPerIteration[_iteration]);
            GrowtSimulation();

            _iteration++;
        }

        private void GrowtSimulation()
        {
            _simulationEngine.MapController.CopyMap();

            List<Node> nodesToRandom = new List<Node>();
            for (int x = 1; x <= _simulationEngine.Configuration.Width; x++)
            {
                for (int y = 1; y <= _simulationEngine.Configuration.Height; y++)
                {
                    var node = _simulationEngine.MapController.GetCurrentNode(x, y);
                    if((node.Type == TypeEnum.Grain || node.Type == TypeEnum.Recrystallization) && HasRecrNein(node))
                        nodesToRandom.Add(node);
                }
            }

            if (!nodesToRandom.Any())
                return;

            do
            {
                int randIndex = _random.Next(nodesToRandom.Count);

                ProcessNode(nodesToRandom[randIndex]);

                nodesToRandom.RemoveAt(randIndex);
            } while (nodesToRandom.Count > 0);
            _simulationEngine.MapController.Commit();
        }
        bool HasRecrNein(Node node)
        {
           return _simulationEngine.MapController.GetNeighbourhoods(node.X, node.Y, NeighbourhoodEnum.Moore, true).Any(k => k.Type == TypeEnum.Recrystallization);
        }
        private void ProcessNode(Node node)
        {
            var neighbourhoodType = _simulationEngine.Configuration.Neighbourhood == NeighbourhoodEnum.Moore2 ? NeighbourhoodEnum.Moore : _simulationEngine.Configuration.Neighbourhood;

            var allNeighbourhoods = _simulationEngine.MapController.GetNeighbourhoods(node.X, node.Y, neighbourhoodType, true).Where(k => k.Type == TypeEnum.Recrystallization || k.Type == TypeEnum.Grain).ToList();
            var otherNeighbourhoods = allNeighbourhoods.Where(k => k.Id != node.Id && k.Type == TypeEnum.Recrystallization).ToList();

            if (!otherNeighbourhoods.Any())
                return;

            var otherIds = otherNeighbourhoods.Select(k => k.Id).Distinct();

            if (otherIds.Count() == 0)
                return;

            double energy_before = GetEnrgy(node.Id, node.X, node.Y, allNeighbourhoods) + node.H;

            int randNodeId = otherIds.ElementAt(_random.Next(otherIds.Count()));
            var newNode = otherNeighbourhoods.FirstOrDefault(k => k.Id == randNodeId);

            double energy_after = GetEnrgy(newNode.Id, node.X, node.Y, allNeighbourhoods);

            if (energy_after - energy_before <= 0)
            {
                var nodeXd = new Node()
                {
                    X = node.X,
                    Y = node.Y,
                    Id = newNode.Id,
                    Color = newNode.Color,
                    Type = newNode.Type
                };
                _simulationEngine.MapController.SetNode(node.X, node.Y, nodeXd);
            }
        }
        private double GetEnrgy(int id, int x, int y, List<Node> neighbourhoods)
        {
            int countOfOthers = neighbourhoods.Count(k => k.Id != id);

            return _simulationEngine.Configuration.J * (double)countOfOthers;
        }
        private void SeedNewNode(int amount)
        {
            double grainEnergy = _simulationEngine.Configuration.GrainEnergy - _simulationEngine.Configuration.GrainEnergy * 0.1;
            double borderEnergy = _simulationEngine.Configuration.BorderEnergy - _simulationEngine.Configuration.BorderEnergy * 0.1;
            List<Node> nodesToRecrystalization = new List<Node>();
            for (int x = 1; x <= _simulationEngine.Configuration.Width; x++)
            {
                for (int y = 1; y <= _simulationEngine.Configuration.Height; y++)
                {
                    var node = _simulationEngine.MapController.GetNode(x, y);
                    if (node.Type == TypeEnum.Grain)
                    {
                        if (_simulationEngine.Configuration.ConfigurationRecrystallization.OnlyGBGeneration)
                        {
                            if (node.H > borderEnergy)
                                nodesToRecrystalization.Add(node);
                        }
                        else
                        {
                            nodesToRecrystalization.Add(node);
                        }
                    }
                }
            }

            if (nodesToRecrystalization.Count == 0)
                return;

            nodesToRecrystalization = nodesToRecrystalization.OrderByDescending(k => k.H).ToList();


            while (amount > 0)
            {
                var grainToSeed = _states[_random.Next(_states.Count)];
                var node = nodesToRecrystalization[_random.Next(nodesToRecrystalization.Count/2)];

                node.Color = grainToSeed.Color;
                node.Id = grainToSeed.Id;
                node.Type = TypeEnum.Recrystallization;
                node.H = 0;

                nodesToRecrystalization.Remove(node);
                amount--;
            }

        }
        private void GenerateListOfStates()
        {
            _states = new List<Grain>();
            int grainsToGenerate = _simulationEngine.Configuration.ConfigurationRecrystallization.NumberOfStates;

            while (grainsToGenerate > 0)
            {
                Grain newGrain = new Grain()
                {
                    Id = 200 + grainsToGenerate
                };

                do
                {
                    newGrain.Color = System.Drawing.Color.FromArgb(_random.Next(255), 0, 0);
                } while (_states.Any(k=>k.Color.ToArgb() == newGrain.Color.ToArgb()));
                _states.Add(newGrain);

                grainsToGenerate--;
            }
        }
        private void GenerateListOfNucleaonsPerIterations()
        {
            int total = _simulationEngine.Configuration.ConfigurationRecrystallization.TotalNucleons;
            int numberOfIterations = _maxIteration;

            _nucleonsPerIteration = new List<int>();
            switch (_simulationEngine.Configuration.ConfigurationRecrystallization.NucleonsType)
            {
                case NucleonsType.BeginOfSimulation:
                    {
                        _nucleonsPerIteration.Add(total);
                        for (int k = 1; k < numberOfIterations; k++)
                        {
                            _nucleonsPerIteration.Add(0);
                        }
                    }
                    break;
                case NucleonsType.Constant:
                    {
                        int addedAcum = 0;
                        double delta = (double)total / (double)numberOfIterations;
                        for ( int k =0; k < numberOfIterations-1; k++)
                        {
                            addedAcum += (int)delta;
                            _nucleonsPerIteration.Add((int)delta);

                        } 
                        _nucleonsPerIteration.Add(total - addedAcum);
                    }
                    break;
                case NucleonsType.Increasing:
                    {
                        int addedAcum = 0;
                        numberOfIterations--;
                        double allTriangle = 0.5 * numberOfIterations * numberOfIterations;
                        double delta, currentField;

                        _nucleonsPerIteration.Add(0);
                        for (int k = 1; k < numberOfIterations; k++)
                        {
                            currentField = 0.5 * (2 * k - 1);
                            delta = currentField / allTriangle;
                            addedAcum += (int)(delta * total);
                            _nucleonsPerIteration.Add((int)(delta * total));
                        }
                        _nucleonsPerIteration.Add(total - (int)addedAcum);
                    }
                    break;
            }
            

        }
    }
}
