using Battleship.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class BattleshipStateTracker
    {
        List<Node> nodes;
        public void CreateBorad(int xDimention, int yDimention)
        {
            if (xDimention <= 0 || yDimention <= 0)
                throw new ArgumentOutOfRangeException();

            nodes = new List<Node>();
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    nodes.Add(new Node { X = x, Y = y, NodeState = NodeState.Empty });
                }
            }
        }

        public List<Battleship.Common.Node> GetBroard()
        {
            return nodes;
        }
    }
}
