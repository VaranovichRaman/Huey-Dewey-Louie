using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    public class YouDie
    {
        public static void MonsterWins()
        {
            Console.WriteLine("You lost the fight. You're dead");
            GameOver.CloseProgram();
        }
    }
}
