using System;
using System.Threading;
using Adventure;
using System.Collections.Generic;

namespace Adventure
{
    class Program
    {

        
        public static void Main()
        {
            // invoke the start method from game class
            Game.Start();
            Console.Read();
        }
    }
}