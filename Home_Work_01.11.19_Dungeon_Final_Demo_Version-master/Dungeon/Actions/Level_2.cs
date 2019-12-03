using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class Level_2
    {
        public string[,] Level2Creation(Hero h)
        {
            //MapCreate m = new MapCreate();
            //var map = m.FloorCreate(h);
            //MapCreate.CreateRoom(3, 3, 3, 3, map);
            //MapCreate.CreateRoom(2, 2, 7, 7, map);
            //MapCreate.CreateRoom(5, 5, 5, 5, map);
            ////m.CreateHeroMark(h.CoordinateX, h.CoordinateY, 0, 0, map, h.KeyAvailability, h);
            ////MapCreate.CreateDoorMark(5, 8, map);
            ////MapCreate.CreateDoorMark(7, 14, map);
            ////MapCreate.CreateDoorMark(4, 22, map);
            ////MapCreate.CreateMonsterMark(5, 5, map);
            ////MapCreate.CreateMonsterMark(3, 14, map);
            ////MapCreate.CreateMonsterMark(5, 22, map);
            ////MapCreate.CreateStairsMark(3, 22, map);
            //m.ShowMap(map);
            //return map;
            MapCreate m = new MapCreate();
            var map = m.FloorCreate(h);
            MapCreate.CreateRoom(4, 7, 4, 22, map);
            MapCreate.CreateRoom(4, 2, 10, 3, map);
            MapCreate.CreateRoom(2, 2, 3, 8, map);
            //m.CreateHeroMark(h.CoordinateX, h.CoordinateY, 0, 0, map, h.KeyAvailability, h);            
            MapCreate.CreateDoorMark(4, 3, map);
            MapCreate.CreateDoorMark(4, 8, map);
            MapCreate.CreateDoorMark(4, 22, map);
            MapCreate.CreateMonsterMark(9, 3, map);
            MapCreate.CreateMonsterMark(6, 14, map);
            MapCreate.CreateMonsterMark(3, 5, map);
            MapCreate.CreateMonsterMark(5, 25, map);
            MapCreate.CreatePrincessMark(11, 3, map);
            MapCreate.CreateStairsMark(3, 22, map);
           
            //m.ShowMap(map);
            return map;
        }
    }
}
