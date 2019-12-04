using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    public class MonsterChoiceAlg
    {
        public static int Result;

        public void HowToFight()
        {
            int.TryParse(Console.ReadLine(), out int PlChoice);
            if (PlChoice == 1 || PlChoice == 2 || PlChoice == 3)
            {
                Result = PlChoice;
            }
            else
            {
                Console.WriteLine("You should choose a way to fight the monster");
                HowToFight();
            }
        }
    }
}
