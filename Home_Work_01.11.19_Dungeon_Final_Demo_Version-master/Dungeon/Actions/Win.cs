using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class Win
    {
        public static void CloseProgram()
        {
            Console.WriteLine($"You win! You can fuck this princess! Bye, bye!!!");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
    }
}
