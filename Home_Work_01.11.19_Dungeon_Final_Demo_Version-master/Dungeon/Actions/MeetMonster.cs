using D_and_D_demo.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    public class MeetMonster
    {
        public static bool MeetingResult;

        public void MonsterChoice()
        {
            Console.WriteLine("You may choose three ways of fight:" +
                "\n1 - Random battle" +
                "\n2 - Play Durak card game" +
                "\n3 - Play Hearthstone game." +
                "\nEnter your choice.");
            MonsterChoiceAlg choice = new MonsterChoiceAlg();
            choice.HowToFight();
            if (MonsterChoiceAlg.Result == 1)
            {
                FightClub club = new FightClub();
                club.RandomFight();
                MeetingResult = club.FightResult;
            }
            else if (MonsterChoiceAlg.Result == 2)
            {
                StartDurakGame durak = new StartDurakGame();
                durak.PlayDurak();
                MeetingResult = durak.DurakResult;
            }
            else if (MonsterChoiceAlg.Result == 3)
            {
                StartHearthstoneGame hs = new StartHearthstoneGame();
                hs.StartHS();
                MeetingResult = hs.HearthStoneResult;
            }
        }

    }
}
