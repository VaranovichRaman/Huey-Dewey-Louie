using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon.Actions;

namespace Dungeon.Model
{
    public class HSCard
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public HSSpecificHandler Handler { get; set; }
    }
}
