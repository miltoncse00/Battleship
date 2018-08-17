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
        BattleshipStateTrackerStab battleshipStateTracker1;
        BattleshipStateTrackerStab battleshipStateTracker2;

        TwoPlayerBattleshipMediator battleshipMediator;

        [TestInitialize]
        public void Initilize()
        {

            battleshipMediator = new TwoPlayerBattleshipMediator();
            battleshipStateTracker1 = new BattleshipStateTrackerStab(battleshipMediator);

        }

        [TestMethod]
        public void GivenABattleShipGenerator_WhenCreateBoardWithDimention_ThenGridWithNoOccupation()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard1(xLength, yLength);
            Assert.AreEqual(board.Count, xLength * yLength);
            var nodeStateCount = board.Select(s => s.NodeState == NodeState.Empty).Count();
            Assert.IsTrue(nodeStateCount == xLength * yLength);
        }

        private List<Node> GenerateBoard1(int xLength, int yLength)
        {
            battleshipStateTracker1.CreateBorad(xLength, yLength);
            List<Node> board = battleshipStateTracker1.GetBroard();
            return board;
        }

        private List<Node> GenerateBoard2(int xLength, int yLength)
        {
            battleshipStateTracker2.CreateBorad(xLength, yLength);
            List<Node> board = battleshipStateTracker2.GetBroard();
            return board;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Given_BattleShipGenerator_When_CreateBoardWithInvalidDimention_ThenWillReturnArguemntException()
        {
            int xLength = 0;
            int yLength = 10;
            List<Node> board = GenerateBoard1(xLength, yLength);
        }

        [TestMethod]
        public void Given_BattleshipGenerator_When_AddShipofLengthN_2_X_1_Y_1_Horizontal_ThenNodesWillBeOccupied()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard1(xLength, yLength);
            battleshipStateTracker1.AddAShipToBoard(2, 1, 1, Orientation.Horizontal);

            Assert.IsTrue(board.Any(s => s.X == 1 && s.Y == 1 && s.NodeState == NodeState.Occupied));
            Assert.IsTrue(board.Any(s => s.X == 2 && s.Y == 1 && s.NodeState == NodeState.Occupied));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Given_BattleshipGenerator_When_AddShipofOutsideLengthN_2_X_9_Y_1_Horizontal_ThenWillThrowException()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard1(xLength, yLength);
            battleshipStateTracker1.AddAShipToBoard(2, 10, 1, Orientation.Horizontal);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Given_BattleshipGenerator_When_Attack_at_Position_ReturnException()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard1(xLength, yLength);
            battleshipMediator._player1 = battleshipStateTracker1;
            NodeState nodeState = battleshipStateTracker1.Attack(1, 1);

        }


        [TestMethod]
        public void Given_BattleshipGenerator_When_Attack_at_PositionWithSecondPlayerWithoutShip_ReturnMissed()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard1(xLength, yLength);
            battleshipMediator._player1 = battleshipStateTracker1;
            battleshipStateTracker2 = new BattleshipStateTrackerStab(battleshipMediator);

            GenerateBoard2(xLength, yLength);
            battleshipMediator._player2 = battleshipStateTracker2;

            NodeState nodeState = battleshipStateTracker1.Attack(1, 1);
            Assert.IsTrue(nodeState == NodeState.Miss);

        }


        [TestMethod]
        public void Given_BattleshipGenerator_When_Attack_at_PositionWithSecondPlayerAllShipHit_ReturnAllBattleshipSunk()
        {
            int xLength = 10;
            int yLength = 10;
            List<Node> board = GenerateBoard1(xLength, yLength);
            battleshipMediator._player1 = battleshipStateTracker1;
            battleshipStateTracker2 = new BattleshipStateTrackerStab(battleshipMediator);

            GenerateBoard2(xLength, yLength);
            battleshipMediator._player2 = battleshipStateTracker2;
            battleshipStateTracker2.AddAShipToBoard(1, 1, 1, Orientation.Horizontal);
            NodeState nodeState = battleshipStateTracker1.Attack(1, 1);
            string message = battleshipStateTracker1.GetMessage();
            Assert.IsTrue(message == Resources.AllBattleShipAreSunk);

        }

    }
}
