using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Common
{
    public class Node
    {
        public Node(int x, int y)
        {
            X = x;
            Y = y;
            NodeState = NodeState.Empty;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public NodeState NodeState { get; private set; }

        public void Occupy()
        {
            NodeState = NodeState.Occupied;
        }

        public NodeState Attacked()
        {
            if (NodeState == NodeState.Empty)
            {
                NodeState = NodeState.Miss;
            }
            else if (NodeState == NodeState.Occupied)
            {
                NodeState = NodeState.Hit;
            }
            return NodeState;
        }
    }
}
