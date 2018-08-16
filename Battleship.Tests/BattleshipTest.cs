using Battleship.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Tests
{
    [TestClass]
    public class BattleshipTest
    {
        [TestMethod]
        public void GivenABattleShipGenerator_WhenCreateBoardWithDimention_ThenGridWithNoOccupation()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard(xLength, yLength);
            Assert.AreEqual(board.Count, xLength * yLength);
            var nodeStateCount = board.Select(s => s.NodeState == NodeState.Empty).Count();
            Assert.IsTrue(nodeStateCount ==  xLength * yLength);
        }

        private static List<Node> GenerateBoard(int xLength, int yLength)
        {
            var battleshipGenerator = new BattleshipStateTracker();
            battleshipGenerator.CreateBorad(xLength, yLength);
            List<Node> board = battleshipGenerator.GetBroard();
            return board;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Given_BattleShipGenerator_When_CreateBoardWithInvalidDimention_ThenWillReturnArguemntException()
        {
            int xLength = 0;
            int yLength = 10;
            List<Node> board = GenerateBoard(xLength, yLength);         

        }

        [TestMethod]
        public void Given_BattleshipGenerator_When_AddShipofLengthN_2X_0Y_0_Horizontal_ThenNodesWillBeOccupied()
        {

        }

    }
}
