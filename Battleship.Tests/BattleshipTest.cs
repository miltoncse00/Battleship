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
        BattleshipGenerator battleshipGenerator;

        [TestInitialize]
        public void Initilize()
        {
            battleshipGenerator = new BattleshipGenerator();
        }

        [TestMethod]
        public void GivenABattleShipGenerator_WhenCreateBoardWithDimention_ThenGridWithNoOccupation()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard(xLength, yLength);
            Assert.AreEqual(board.Count, xLength * yLength);
            var nodeStateCount = board.Select(s => s.NodeState == NodeState.Empty).Count();
            Assert.IsTrue(nodeStateCount == xLength * yLength);
        }

        private List<Node> GenerateBoard(int xLength, int yLength)
        {
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
        public void Given_BattleshipGenerator_When_AddShipofLengthN_2_X_1_Y_1_Horizontal_ThenNodesWillBeOccupied()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard(xLength, yLength);
            battleshipGenerator.AddAShipToBoard(2, 1, 1, Orientation.Horizontal);

            Assert.IsTrue(board.Any(s => s.X == 1 && s.Y == 1 && s.NodeState == NodeState.Occupied));
            Assert.IsTrue(board.Any(s => s.X == 3 && s.Y == 1 && s.NodeState == NodeState.Occupied));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Given_BattleshipGenerator_When_AddShipofOutsideLengthN_2_X_9_Y_1_Horizontal_ThenWillThrowException()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard(xLength, yLength);
            battleshipGenerator.AddAShipToBoard(2, 9, 1, Orientation.Horizontal);          
        }

    }
}
