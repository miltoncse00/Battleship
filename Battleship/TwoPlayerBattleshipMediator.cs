using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Common;

namespace Battleship
{
    public class TwoPlayerBattleshipMediator : BattleshipMediator
    {
        public BattleshipStateTracker _player1;
        public BattleshipStateTracker _player2;

        public override NodeState SendAttackNotification(int x, int y, BattleshipStateTracker player)
        {
            if (_player1 == player)
                return _player2.SendAttackNotification(x, y);
            else if (_player2 == player)
                return _player1.SendAttackNotification(x, y);
            else
                return NodeState.Empty;
        }

        internal override void SendMessageToReceiver(string allBattleShipAreSunk, BattleshipStateTracker player)
        {
            if (_player1 == player)
                _player2.ReceiveNotification(allBattleShipAreSunk);
            else if (_player2 == player)
                _player1.ReceiveNotification(allBattleShipAreSunk);
        }
    }
}
