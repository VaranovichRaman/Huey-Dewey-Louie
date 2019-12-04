using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class StartDurakGame
    {
        public bool PlayDurak()
        {
            DurakGameplay game = new DurakGameplay();
            game.Play();
            return DurakGameplay.GameResult;
        }
    }
}
