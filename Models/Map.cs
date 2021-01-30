using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Models
{
    public class Map
    {
        private Node[,] _nodes;
        private int _width;
        private int _height;
        public Map(int width, int height)
        {
            _nodes = new Node[width, height];
            _width = width;
            _height = height;
        }

        public Node GetNode(int x, int y)
        // Accessing the node.
        // Uzyskiwanie dostępu do węzła.
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
                return _nodes[x, y];
            return null;
        }
        public void SetNode (Node node, int x, int y)
        // The function enables converting a fragment of the result tree into a node set.
        // Funkcja umożliwia konwertowanie fragmentu drzewa wynikowego na zestaw węzłów.
        {
            if (x>=0 && y>= 0 && x<_width&&y<_height)
                _nodes[x, y] = node;
        }

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
    }
}
