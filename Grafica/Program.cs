using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(800,800))
            { game.Run(30.0); }
        }
    }
}
