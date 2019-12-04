using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    public class Skip
    {
        public void SkipGame()
        {
            Console.WriteLine("You skipped the match. Choose another way to kill the Monster");
            MeetMonster skip = new MeetMonster();
            skip.MonsterChoice();
        }
    }
}
