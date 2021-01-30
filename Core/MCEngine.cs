using MultiscaleModelling.Controllers;
using MultiscaleModelling.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiscaleModelling.Interfaces;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Core
{
    class MCEngine : IProcessable
    {
        private SimulationEngine _simulationEngine;
        private Random _random;
        private int _currentMCIteration;

        public MCEngine(Random random, SimulationEngine simulationEngine)
        {
            _random = random;
            _simulationEngine = simulationEngine;
        }

        public void InitializeStep()
        {
            _simulationEngine.MapController.CopyMap();
            _simulationEngine.Grains = new List<Grain>();
            int grainsToGenerate = _simulationEngine.Configuration.NumberOfGrains;
            while (grainsToGenerate > 0)
            {
                var grain = _simulationEngine.GetRandomGrain();
                _simulationEngine.Grains.Add(grain);
                grainsToGenerate--;
            }


            for (int x = 1; x <= _simulationEngine.Configuration.Width; x++)
            {
                for (int y = 1; y <= _simulationEngine.Configuration.Height; y++)
                {
                    var oldNode = _simulationEngine.MapController.GetNode(x, y);
                    if (oldNode.Type == TypeEnum.Empty)
                    {
                        var grain = _simulationEngine.Grains[_random.Next(_simulationEngine.Grains.Count)];
                        var node = new Node()
                        {
                            X = x,
                            Y = y,
                            Id = grain.Id,
                            Color = grain.Color,
                            Type = TypeEnum.Grain
                        };
                        _simulationEngine.MapController.SetNode(x, y, node);
                    }
                }
            }
            _simulationEngine.MapController.Commit();

            _currentMCIteration = _simulationEngine.Configuration.MCIterations - 1;
            _simulationEngine.GenerateListOfGrains();
        }
        public void NextStep()
        {

            List<Point> postitionToRandom = new List<Point>();
            for (int x = 1; x <= _simulationEngine.Configuration.Width; x++)
                for (int y = 1; y <= _simulationEngine.Configuration.Height; y++)
                    postitionToRandom.Add(new Point(x, y));


            _simulationEngine.MapController.CopyMap();
            do
            {
                int randIndex = _random.Next(postitionToRandom.Count);

                ProcessCoordinateMonteCarlo(postitionToRandom[randIndex].X, postitionToRandom[randIndex].Y);

                postitionToRandom.RemoveAt(randIndex);
            } while (postitionToRandom.Count > 0);
            _simulationEngine.MapController.Commit();



            _currentMCIteration--;

            if (_currentMCIteration > 0)
                _simulationEngine.EndSimulation = false;
            else
                _simulationEngine.EndSimulation = true;


            if (_simulationEngine.EndSimulation)
            {
                _simulationEngine.EndSubstructureSimulation();
            }
        }

        private void ProcessCoordinateMonteCarlo(int x, int y)
        {
            var neighbourhoodType = _simulationEngine.Configuration.Neighbourhood == NeighbourhoodEnum.Moore2 ? NeighbourhoodEnum.Moore : _simulationEngine.Configuration.Neighbourhood;
            var node = _simulationEngine.MapController.GetCurrentNode(x, y);
            if (node.Type != TypeEnum.Grain)
                return;
            var allNeighbourhoods = _simulationEngine.MapController.GetNeighbourhoods(x, y, neighbourhoodType, true).Where(k => k.Type == TypeEnum.Grain).ToList();
            var otherNeighbourhoods = allNeighbourhoods.Where(k => k.Id != node.Id).ToList();
            var otherIds = otherNeighbourhoods.Select(k => k.Id).Distinct();

            if (otherIds.Count() == 0)
                return;

            double energy_before = GetEnrgy(node.Id, x, y, allNeighbourhoods);

            int randNodeId = otherIds.ElementAt(_random.Next(otherIds.Count()));
            var newNode = otherNeighbourhoods.FirstOrDefault(k => k.Id == randNodeId);

            double energy_after = GetEnrgy(newNode.Id, x, y, allNeighbourhoods);

            if (energy_after - energy_before <= 0)
            {
                var nodeXd = new Node()
                {
                    X = x,
                    Y = y,
                    Id = newNode.Id,
                    Color = newNode.Color,
                    Type = newNode.Type
                };
                _simulationEngine.MapController.SetNode(x, y, nodeXd);
            }
        }
        private double GetEnrgy(int id, int x, int y, List<Node> neighbourhoods)
        {
            int countOfOthers = neighbourhoods.Count(k => k.Id != id);

            return _simulationEngine.Configuration.J * (double)countOfOthers;
        }
    }
}
