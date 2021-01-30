using MultiscaleModelling.Controllers;
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
    class CAEngine : IProcessable
    {

        private SimulationEngine _simulationEngine;
        private Random _random;

        public CAEngine(Random random, SimulationEngine simulationEngine)
        {
            _random = random;
            _simulationEngine = simulationEngine;
        }

        public void InitializeStep()
        {
            // Seed grains.
            // Rozmieść ziarna.
            int grainsToGenerate = _simulationEngine.Configuration.NumberOfGrains;
            while (grainsToGenerate > 0)
            // while - the statement executes a statement or a block of statements when the specified logical expression returns true.
            // while - instrukcja wykonuje instrukcję lub blok instrukcji, gdy określone wyrażenie logiczne zwraca wartość true.
            {
                var grain = _simulationEngine.GetRandomGrain();
                _simulationEngine.Grains.Add(grain);
                AddGrainToRandomPosition(grain);

                _simulationEngine.MapController.Commit();
                _simulationEngine.MapController.CopyMap();
                grainsToGenerate--;
            }

            _simulationEngine.GenerateListOfGrains();
        }
        public void NextStep()
        {
            _simulationEngine.EndSimulation = true;
            for (int x = 1; x <= _simulationEngine.Configuration.Width; x++)
            // for - statement executes a statement or a block of statements when the specified logical expression returns true.
            // for - instrukcja wykonuje instrukcję lub blok instrukcji, gdy określone wyrażenie logiczne zwraca wartość true.
            {
                for (int y = 1; y <= _simulationEngine.Configuration.Height; y++)
                {
                    ProcessCoordinate(x, y);
                }
            }
            _simulationEngine.MapController.Commit();


            if (_simulationEngine.EndSimulation)
            // if -the statement specifies which statement to run based on the value of the logical expression.
            // if - instrukcja określa, która instrukcja ma być uruchamiana na podstawie wartości wyrażenia logicznego.
            {
                _simulationEngine.EndSubstructureSimulation();
            }
        }

        private void AddGrainToRandomPosition(Grain grain)
        {
            int x, y;
            bool correctCoordinate = false;
            do
            /* do - statement executes a statement or a block of statements when the specified Boolean expression 
             * returns true. Because this expression is evaluated each time the loop is executed, the do-while loop 
             * executes one or more times. This is different from a while loop which executes zero or more times.
             * do - instrukcja wykonuje instrukcję lub blok instrukcji, gdy określone wyrażenie logiczne zwraca 
             * wartość true . Ponieważ to wyrażenie jest oceniane po każdym wykonaniu pętli, do-while Pętla 
             * wykonuje jeden lub więcej razy. Różni się to od pętli while , która wykonuje zero lub więcej razy.
             */
            {
                x = _random.Next(1, _simulationEngine.Configuration.Width);
                y = _random.Next(1, _simulationEngine.Configuration.Height);

                correctCoordinate = _simulationEngine.MapController.GetNode(x, y).Type == TypeEnum.Empty;
            } while (!correctCoordinate);

            var node = new Node()
            {
                X = x,
                Y = y,
                Color = grain.Color,
                Id = grain.Id,
                Type = TypeEnum.Grain
            };

            _simulationEngine.MapController.SetNode(x, y, node);
        }
        private void ProcessCoordinate(int x, int y)
        {
            var node = _simulationEngine.MapController.GetNode(x, y);

            if (node.Type == TypeEnum.Empty)
            {
                _simulationEngine.EndSimulation = false;

                node = GetNodeForCA(node, _simulationEngine.Configuration.Neighbourhood);
            }


            _simulationEngine.MapController.SetNode(x, y, new Node()
            {
                X = x,
                Y = y,
                Id = node.Id,
                Color = node.Color,
                Type = node.Type
            });
        }
        private Node GetNodeForCA(Node node, NeighbourhoodEnum type)
        {
            switch (type)
            // switch - The statement is often used as an alternative to an if-else construct if a single expression is tested against three or more conditions.
            // switch - instrukcja jest często używana jako alternatywa dla konstrukcji if-else , jeśli pojedyncze wyrażenie jest testowane w oparciu o trzy lub więcej warunków.
            {
                case NeighbourhoodEnum.Moore:
                case NeighbourhoodEnum.VonNeumann:
                    return GetNodeforStandardMethod(node);
                case NeighbourhoodEnum.Moore2:
                    return GetNodeforModificationMethod(node);
            }
            return null;
        }
        private Node GetNodeforStandardMethod(Node node)
        {
            var neighbourhood = _simulationEngine.MapController.GetNeighbourhoods(node.X, node.Y, _simulationEngine.Configuration.Neighbourhood);

            neighbourhood = neighbourhood.Where(k => k.Type == TypeEnum.Grain).ToList();
            if (neighbourhood.Any())
            {
                var orderedNeighbourhood = neighbourhood.GroupBy(s => s).Select(g => new KeyValuePair<Node, int>(g.First(), g.Count())).OrderByDescending(p => p.Value).ToList();
                var winnerValue = orderedNeighbourhood.FirstOrDefault().Value;

                var winners = orderedNeighbourhood.Where(p => p.Value == winnerValue).ToList();
                var randomWinner = winners[_random.Next(winners.Count)].Key;

                node = randomWinner;
            }

            return node;
        }
        private Node GetNodeforModificationMethod(Node node)
        {
            var mooreNeighbourhood = GetListOfGrainNeighbourhood(node, NeighbourhoodEnum.Moore);
            if (mooreNeighbourhood == null || !mooreNeighbourhood.Any())
                return node;
            if (mooreNeighbourhood.FirstOrDefault().Value >= 5)
            {
                return mooreNeighbourhood.FirstOrDefault().Key;
            }

            var secondNeighbourhood = GetListOfGrainNeighbourhood(node, NeighbourhoodEnum.VonNeumann);
            if (secondNeighbourhood != null && secondNeighbourhood.FirstOrDefault().Value >= 3)
            {
                return secondNeighbourhood.FirstOrDefault().Key;
            }

            var trNeighbourhood = GetListOfGrainNeighbourhood(node, NeighbourhoodEnum.Cross);
            if (trNeighbourhood != null && trNeighbourhood.FirstOrDefault().Value >= 3)
            {
                return trNeighbourhood.FirstOrDefault().Key;
            }

            int randomNumber = _random.Next(100);
            if (randomNumber < _simulationEngine.Configuration.MooreProbability)
            {
                var winnerValue = mooreNeighbourhood.FirstOrDefault().Value;
                var winners = mooreNeighbourhood.Where(p => p.Value == winnerValue).ToList();
                return winners[_random.Next(winners.Count)].Key;
            }

            return node;
        }
        private List<KeyValuePair<Node, int>> GetListOfGrainNeighbourhood(Node node, NeighbourhoodEnum type)
        {
            var neighbourhood = _simulationEngine.MapController.GetNeighbourhoods(node.X, node.Y, type);

            neighbourhood = neighbourhood.Where(k => k.Type == TypeEnum.Grain).ToList();

            if (neighbourhood.Any())
            {
                var orderedNeighbourhood = neighbourhood.GroupBy(s => s).Select(g => new KeyValuePair<Node, int>(g.First(), g.Count())).OrderByDescending(p => p.Value).ToList();
                return orderedNeighbourhood;
            }
            return null;
        }

    }
}
