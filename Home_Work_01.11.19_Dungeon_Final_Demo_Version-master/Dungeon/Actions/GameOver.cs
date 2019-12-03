using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dungeon.Actions
{
    class GameOver
    {
        public static void CloseProgram()
        {
            Console.Clear();
            Console.WriteLine($"GAME OVER!!!");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
    }
}
