using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dungeon.Model;

namespace Dungeon.Actions
{
    public class StartHearthstoneGame
    {
        public bool HearthStoneResult;

        public void StartHS()
        {
            var rnd = new Random();
            var Player = new HSPlayer();
            var Ai = new HSPlayer();
            Player.CreatePlayer(Player, "HSDeck1.json");
            Ai.CreatePlayer(Ai, "HSDeck2.json");
            //GAME
            Player.AddMinion(Player);
            Ai.AddRandomMinion(Ai);
            while (Player.Hp > 0 && Ai.Hp > 0)
            {
                Thread.Sleep(1000);
                Player.ChooseTargetAndAttack(Player, Ai);
                Player.AddMinion(Player);
                Ai.Attack(Ai, Player);
                Ai.AddRandomMinion(Ai);
            }
            HearthStoneResult = HSPlayer.MatchResult; 

        }

    }
}
