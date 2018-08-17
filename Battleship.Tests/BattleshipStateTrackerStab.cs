using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Tests
{
    public class BattleshipStateTrackerStab : BattleshipStateTracker
    {
        public BattleshipStateTrackerStab(BattleshipMediator battleshipMediator) : base(battleshipMediator)
        {
        }

        public List<Battleship.Common.Node> GetBroard()
        {
            return nodes;
        }
        
        public string GetMessage()
        {
            return receivedMessage;
        }
    }
}
