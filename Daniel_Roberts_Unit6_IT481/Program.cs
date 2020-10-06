using System;
using System.Threading;

namespace Daniel_Roberts_Unit6_IT481
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenario01();
            Console.ReadKey();
        }

        public static void Scenario01()
        {
            Scenario test = new Scenario(5, 10);
            Thread.Sleep(1000);
            test.Run();
            Console.WriteLine("Scenario " + nameof(test) + " has begun.");
            Console.WriteLine(Scenario.totalTime.ToString());
        }

    }
}
