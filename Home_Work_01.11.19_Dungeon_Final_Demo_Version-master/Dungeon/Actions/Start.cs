using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class Start
    {
        CreateHero hero = new CreateHero();
        //MapCreate map = new MapCreate();
        Controls controls = new Controls();
        Check check = new Check();
        Level_1 lvl1 = new Level_1();
        Level_2 lvl2 = new Level_2();
        public void StartOn()
        {
            Hero h = CreateHero.HeroCreation();
            h.HeroAtLevel1 = true;
            h.HeroAlive = true;
            var map1 = lvl1.Level1Creation(h);
            var map2 = lvl2.Level2Creation(h);
            controls.ControlButtons(h,map1, map2);



        }
    }
}
