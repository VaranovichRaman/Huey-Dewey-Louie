﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dungeon.Model;

namespace Dungeon.Actions

{
    public class HSPlayer
    {
        public int Hp { get; set; }
        public List<HSCard> Deck { get; set; }
        public List<HSCard> Hand { get; set; }
        public List<HSCard> Table { get; set; }

        public static bool MatchResult;

        public void CreatePlayer(HSPlayer player, string path)
        {
            var deck = new HSGameService();
            player.Deck = deck.CreateDeck(path);
            player.Hp = 30;
            player.Hand = player.Deck.GetRange(0, 3);
            player.Deck.RemoveRange(0, 3);
            player.Table = new List<HSCard>();
        }
        public void AddMinion(HSPlayer player)
        {
            player.Hand.Add(player.Deck[0]);
            player.Deck.RemoveAt(0);
            while (true)
            {
                Console.WriteLine("\nChoose the minion you want to put on the table" +
                    "\n(or enter \"9\" to find another way to kill the Monster)");
                for (int i = 0; i < player.Hand.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {player.Hand[i].Name}, {player.Hand[i].Damage}/{player.Hand[i].Health}");
                }
                int ind = int.Parse(Console.ReadLine());
                if (ind > player.Hand.Count) Console.WriteLine("I don't understand you.");
                else if (ind == 9)
                {
                    Skip skip = new Skip();
                    skip.SkipGame();
                }
                else
                {
                    player.Table.Add(player.Hand[ind - 1]);
                    Console.WriteLine($"You chose {player.Hand[ind - 1].Name}, {player.Hand[ind - 1].Damage}/{player.Hand[ind - 1].Health}. It's on your table. \n\nAi's turn!");
                    player.Hand.RemoveAt(ind - 1);
                    break;
                }
            }

        }

        public void AddRandomMinion(HSPlayer player)
        {
            var rnd = new Random();
            player.Hand.Add(player.Deck[0]);
            player.Deck.RemoveAt(0);
            int ind = rnd.Next(0, player.Hand.Count);
            player.Table.Add(player.Hand[ind]);
            Thread.Sleep(1000);
            Console.WriteLine($"\nAi chose {player.Hand[ind].Name}, {player.Hand[ind].Damage}/{player.Hand[ind].Health}. It's on his table. \n\nYour turn!");
            player.Hand.RemoveAt(ind);

        }
        public void ChooseTargetAndAttack(HSPlayer player, HSPlayer Ai)
        {
            Console.WriteLine("\nIt's time to attack");
            for (int i = 0; i < player.Table.Count; i++)
            {
                Console.WriteLine($"You have to choose a target to attack with {player.Table[i].Name}, {player.Table[i].Damage}/{player.Table[i].Health}:");
                for (int s = 0; s < Ai.Table.Count; s++)
                {
                    Console.WriteLine($"{s + 1} - {Ai.Table[s].Name}, {Ai.Table[s].Damage}/{Ai.Table[s].Health}");
                }
                Console.WriteLine($"{Ai.Table.Count + 1} - go to face. Now Ai has {Ai.Hp} HP");
                int attacked = int.Parse(Console.ReadLine());
                if (attacked == Ai.Table.Count + 1)
                {
                    Ai.Hp -= player.Table[i].Damage;
                    Console.WriteLine($"You decided go to enemy face. Now Ai has {Ai.Hp} HP");
                    if (Ai.Hp <= 0)
                    {
                        Win();
                    }
                }
                else if (attacked <= Ai.Table.Count)
                {
                    Console.WriteLine($"{player.Table[i].Name}, {player.Table[i].Damage}/{player.Table[i].Health} attacks {Ai.Table[attacked - 1].Name}, {Ai.Table[attacked - 1].Damage}/{Ai.Table[attacked - 1].Health}!");
                    Ai.Table[attacked - 1].Health -= player.Table[i].Damage;
                    player.Table[i].Health -= Ai.Table[attacked - 1].Damage;
                    if (Ai.Table[attacked - 1].Health <= 0)
                    {
                        Console.WriteLine($"Oh no, {Ai.Table[attacked - 1].Name} is dead!");
                        Ai.Table.RemoveAt(attacked - 1);
                    }
                    if (player.Table[i].Health <= 0)
                    {
                        Console.WriteLine($"Oh no, {player.Table[i].Name} is dead!");
                        player.Table.RemoveAt(i);
                    }
                }
                if (Ai.Hp <= 0)
                {
                    Win();
                }
            }

        }
        public void Attack(HSPlayer Ai, HSPlayer player)
        {
            if (Ai.Table.Count != 0)
            {
                Console.WriteLine("Ai attacks!");
                Thread.Sleep(700);
                for (int i = 0; i < Ai.Table.Count; i++)
                {
                    for (int j = 0; j < player.Table.Count; j++)
                    {
                        if (Ai.Table[i].Damage >= player.Table[j].Health)
                        {
                            Console.WriteLine($"{Ai.Table[i].Name} attacks your {player.Table[j].Name}!");
                            player.Table[j].Health -= Ai.Table[i].Damage;
                            Ai.Table[i].Health -= player.Table[j].Damage;

                            if (Ai.Table[i].Health <= 0)
                            {
                                Console.WriteLine($"Oh no, {Ai.Table[i].Name} is dead!");
                                Ai.Table.Remove(Ai.Table[i]);
                            }
                            if (player.Table[j].Health <= 0)
                            {
                                Console.WriteLine($"Oh no, {player.Table[j].Name} is dead!");
                                player.Table.Remove(player.Table[j]);
                            }
                        }
                        else
                        {
                            player.Hp -= Ai.Table[i].Damage;
                            Console.WriteLine($"{Ai.Table[i].Name} goes to your face! Now you have {player.Hp} HP.");
                            break;
                        }
                    }
                    if (player.Hp <= 0)
                    {
                        Lose();
                    }
                }
            }
            else Console.WriteLine("There are no minions on Ai's table.");
        }
        public void Lose()
        {
            Console.WriteLine("Player is dead! You lost!");
            MatchResult = false;
        }
        public void Win()
        {
            Console.WriteLine("You won!");
            MatchResult = true;
        }
    }
}
