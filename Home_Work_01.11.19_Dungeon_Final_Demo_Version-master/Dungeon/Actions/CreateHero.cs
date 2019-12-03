using D_and_D_demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class CreateHero
    {
        public static Hero HeroCreation()
        {
            Hero newHero = new Hero();
            newHero.HeroWeapon = new Weapon();
            newHero.HeroWeapon.Demage = new DemageDice();
            newHero.HeroWeapon.Demage.SizeOfDice = new DiceSize();
            newHero.HeroWeapon.WeaponName = "sword";
            newHero.HeroWeapon.Demage.NumberOfDices = 1;
            newHero.HeroWeapon.Demage.SizeOfDice = (DiceSize)int.Parse(10.ToString());
            //newHero.HeroName = Console.ReadLine();
            newHero.HeroHitPoints = 35;
            newHero.CoordinateX = 4;
            newHero.CoordinateY = 4;
            newHero.HeroArmor = 13;
            newHero.HeroAttackMod = 2;
            newHero.HeroLevel = 1;
            newHero.HeroName = "Bongo";
            return newHero;
        }        
    }
}
