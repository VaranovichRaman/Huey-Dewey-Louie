using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class MapCreate
    {
        Check check = new Check();
        public string[,] Map()
        {
            string[,] map = new string[100, 100];
            return map;
        }
        public string[,] FloorCreate(Hero hero)
        {
            var map = Map(); 
            FillMap(map);
            return map;
        }
        public void FillMap(string[,] map)
        {
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    map[i, j] = " ";
                }
            }
        }
        public static void CreateRoom(int baseX, int baseY, int x, int y, string[,] map)
        {
            for (int i = baseX; i < baseX + x; i++)
            {
                for (int j = baseY; j < baseY + y; j++)
                {
                    if (i == baseX || i == (baseX + x) - 1 || j == baseY || j == (baseY + y) - 1)
                    {
                        map[i, j] = "0";
                    }
                    else
                    {
                        map[i, j] = ".";
                    }
                }
            }
        }
        public static void CreateDoorMark(int x, int y, string[,] map)
        {
            map[x, y] = "D";
        }
        public static void CreateMonsterMark(int x, int y, string[,] map)
        {
            map[x, y] = "M";
        }
        public static void CreateStairsMark(int x, int y, string[,] map)
        {
            map[x, y] = "S";
            map[x, y + 1] = "0";
            map[x - 1, y] = "0";
            map[x - 1, y + 1] = "0";
            map[x - 1, y - 1] = "0";
            map[x, y - 1] = "0";
        }
        public static void CreatePrincessMark(int x, int y, string[,] map)
        {
            map[x, y] = "P";
        }
        public bool CreateHeroMark(int x, int y, int baseX, int baseY, string[,] map, bool key, Hero hero)
        {
            string checkObj = check.WallDoorMonsterStairsCheck(x, y, map, hero);
            if (checkObj == "wall")
            {
                return false;
            }
            else if (checkObj == "door")
            {
                return false;
            }
            else if (checkObj == "stairs")
            {
                Console.Clear();
                if (hero.HeroAtLevel1)
                {
                    Level_2 lvl2 = new Level_2();
                    Level_1 lvl1 = new Level_1();
                    hero.HeroAtLevel2 = true;
                    hero.HeroAtLevel1 = false;
                    lvl2.Level2Creation(hero);
                    //for (int i = 0; i < 50; i++)
                    //{
                    //    for (int j = 0; j < 50; j++)
                    //    {
                    //        map[i, j] = "@";
                    //    }
                        map[x, y] = "S";
                        map[x, y + 1] = "0";
                        map[x - 1, y] = "0";
                        map[x - 1, y + 1] = "0";
                        map[x - 1, y - 1] = "0";
                        map[x, y - 1] = "0";
                        map[x + 1, y] = "H";
                        hero.CoordinateX += 2;
                    //HeroMoveClear(baseX, baseY, map);

                    //map[x, y + 1] = "0";
                    //map[x, y + 1] = "0";
                    //map[x, y - 1] = "0";
                    //map[x - 1, y + 1] = "0";
                    //map[x - 1, y - 1] = "0";
                    //map[x - 1, y] = "0";
                    //return true;
                //}
            }
            else
            {
                Level_1 lvl1 = new Level_1();
                Level_2 lvl2 = new Level_2();
                hero.HeroAtLevel1 = true;
                hero.HeroAtLevel2 = false;
                lvl1.Level1Creation(hero);
                    //for (int i = 0; i < 35; i++)
                    //{
                    //    for (int j = 0; j < 35; j++)
                    //    {
                    //        map[i, j] = " ";
                    //    }
                    //    map[x, y] = "S";
                    //    map[x, y + 1] = "0";
                    //    map[x - 1, y] = "0";
                    //    map[x - 1, y + 1] = "0";
                    //    map[x - 1, y - 1] = "0";
                    //    map[x, y - 1] = "0";
                    //    map[x + 1, y] = "H";
                    //    hero.CoordinateX += 1;
                    //    //return true;
                    //}
                    map[x, y] = "S";
                    map[x, y + 1] = "0";
                    map[x - 1, y] = "0";
                    map[x - 1, y + 1] = "0";
                    map[x - 1, y - 1] = "0";
                    map[x, y - 1] = "0";
                    map[x + 1, y] = "H";
                    hero.CoordinateX += 1;
                }
                return true;
            }
            else
            {
                map[x, y] = "H";
                HeroMoveClear(baseX, baseY, map);
                return true;
            }
        }
        public void HeroMoveClear(int x, int y, string[,] map)
        {
            map[x, y] = ".";
        }
        public void ShowMap(string[,] map)
        {
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (j < 34)
                    {
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        Console.WriteLine(map[i, j]);
                    }

                }
            }
            Console.WriteLine($"Controls: \"W\" - up,\t\t\tLegend: \"H\" - hero,\n\t  \"S\" - down,\t\t\t\t\"M\" - monster," +
                $"\n\t  \"A\" - left,\t\t\t\t\"D\" - door, \n\t  \"D\" - right,\t\t\t\t\"S\" - stairs. \n\t  \"Backspace\" - shut down.");
        }
    }
}
