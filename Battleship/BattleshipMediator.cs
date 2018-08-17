using Battleship.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class BattleshipMediator
    {       
        public abstract NodeState SendAttackNotification(int x, int y, BattleshipStateTracker playerStateTracker);
        internal abstract void SendMessageToReceiver(string allBattleShipAreSunk, BattleshipStateTracker battleshipStateTracker);
    }
}
