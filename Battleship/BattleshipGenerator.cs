﻿using Battleship.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class BattleshipGenerator
    {
        List<Node> nodes;
        int _xDimension = 0;
        int _yDimension = 0;
        public void CreateBorad(int xDimension, int yDimension)
        {
            if (xDimension <= 0 || yDimension <= 0)
                throw new ArgumentOutOfRangeException();
            _xDimension = xDimension;
            _yDimension = yDimension;

            nodes = new List<Node>();
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    nodes.Add(new Node(x, y));
                }
            }
        }

        public List<Battleship.Common.Node> GetBroard()
        {
            return nodes;
        }

        public void AddAShipToBoard(int length, int xTop, int yTop, Orientation orientation)
        {
            var xBottom = xTop;
            var yBottom = yTop;
            if (orientation == Orientation.Vertical)
                yBottom = yBottom + length;
            else
                xBottom = xBottom + length;
            if (yBottom > _yDimension || xBottom > _xDimension)
                throw new ArgumentOutOfRangeException();

            for (var x = xTop; x <= xBottom; x++)
            {
                for (var y = yTop; y <= yBottom; y++)
                {
                    nodes.First(s => s.X == x && s.Y == y).Occupy();
                }
            }
        }
    }
}
