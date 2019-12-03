using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class Level_1
    {
        public string[,] Level1Creation(Hero h)
        {
            MapCreate m = new MapCreate();
            var map = m.FloorCreate(h);
            MapCreate.CreateRoom(3, 3, 5, 9, map);
            MapCreate.CreateRoom(2, 8, 7, 10, map);
            MapCreate.CreateRoom(4, 14, 7, 12, map);
            m.CreateHeroMark(h.CoordinateX, h.CoordinateY, 0, 0, map, h.KeyAvailability, h);
            //h.HeroAtLevel1 = true;
            MapCreate.CreateDoorMark(5, 8, map);
            MapCreate.CreateDoorMark(7, 14, map);
            MapCreate.CreateDoorMark(4, 22, map);
            MapCreate.CreateMonsterMark(5, 5, map);
            MapCreate.CreateMonsterMark(3, 14, map);
            MapCreate.CreateMonsterMark(5, 22, map);
            MapCreate.CreateStairsMark(3, 22, map);
            m.ShowMap(map);            
            return map;
        }
    }
}
