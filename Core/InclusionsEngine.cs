using MultiscaleModelling.Controllers;
using MultiscaleModelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Core
{
    class InclusionsEngine
    {

        private SimulationEngine _simulationEngine;
        private Random _random;


        public InclusionsEngine(Random random, SimulationEngine simulationEngine)
        {
            _random = random;
            _simulationEngine = simulationEngine;
        }

        public void AddInclusions(ConfigurationInclusions config)
        {
            int inclusionsToAdd = config.NumberOfInclusions;
            while (inclusionsToAdd > 0)
            {
                _simulationEngine.MapController.CopyMap();
                AddInclusion(config.InclusionType, config.SizeOfInclusions);
                inclusionsToAdd--;
                _simulationEngine.MapController.Commit();
            }
            _simulationEngine.IsMapEmpty = false;
        }


        private void AddInclusion(InclusionType type, int size)
        {
            var seed = GetSeedForInclusion();

            if (type == InclusionType.Circle)
                GrowCircleInclusion(seed, size);
            else if (type == InclusionType.Square)
                GrowSquareInclusion(seed, size);
        }



        private void GrowCircleInclusion(Node seed, int size)
        {
            double squareSize = Math.Pow((double)size / 2.0, 2);
            for (int x = 1; x <= _simulationEngine.Configuration.Width; x++)
            {
                for (int y = 1; y <= _simulationEngine.Configuration.Height; y++)
                {
                    double distance = (Math.Pow(x - seed.X, 2) + Math.Pow(y - seed.Y, 2));
                    if (distance < squareSize)
                    {
                        var node = _simulationEngine.MapController.GetInclusionNode(x, y);
                        _simulationEngine.MapController.SetNode(x, y, node);
                    }

                }
            }
        }

        private void GrowSquareInclusion(Node seed, int size)
        {

            int halfSize = size / 2;

            for (int x = seed.X - halfSize; x < seed.X - halfSize + size; x++)
            {
                for (int y = seed.Y - halfSize; y < seed.Y - halfSize + size; y++)
                {
                    var node = _simulationEngine.MapController.GetInclusionNode(x, y);
                    _simulationEngine.MapController.SetNode(x, y, node);
                }
            }

        }

        private Node GetSeedForInclusion()
        {
            if (_simulationEngine.EndSimulation)
                return GetSeedForInclusionAfter();
            else
                return GetSeedForInclusionBefore();
        }

        private Node GetSeedForInclusionAfter()
        {
            var edgesdNodes = _simulationEngine.GetListOfEdgesNodes();

            int rand = _random.Next(edgesdNodes.Count);

            return edgesdNodes[rand];
        }

        private Node GetSeedForInclusionBefore()
        {
            int x, y;
            bool correctCoordinate = false;
            do
            {
                x = _random.Next(1, _simulationEngine.Configuration.Width);
                y = _random.Next(1, _simulationEngine.Configuration.Height);

                correctCoordinate = _simulationEngine.MapController.GetNode(x, y).Type == TypeEnum.Empty;
            } while (!correctCoordinate);


            var node = new Node()
            {
                X = x,
                Y = y,
                Id = 3,
                Type = TypeEnum.Inclusion
            };

            return node;
        }




    }
}
