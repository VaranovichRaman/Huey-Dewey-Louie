using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Model
{
    public class HSSpecificHandler
    {
        public HandlerType HandlerType { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
    }

    public enum HandlerType
    {
        None,
        BattleCry,
        DeathRattle
    }
}
