using System;
using System.Threading;

namespace Daniel_Roberts_Unit6_IT481
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenario00();
            Console.ReadKey();
        }

        public static void Scenario00()
        {
            Scenario scenario00 = new Scenario(5, 10);
            Thread.Sleep(1000);
            Console.WriteLine("Scenario " + nameof(scenario00) + " has begun.");
            scenario00.Run();
            Console.WriteLine(Scenario.totalTime.ToString());
        }

        public static void Scenario01()
        {
            Scenario scenario01 = new Scenario(5, 20);
            Thread.Sleep(1000);
            Console.WriteLine("Scenario " + nameof(scenario01) + " has begun.");
            scenario01.Run();
            Console.WriteLine(Scenario.totalTime.ToString());
        }

        public static void Scenario02()
        {
            Scenario scenario02 = new Scenario(10, 20);
            Thread.Sleep(1000);
            Console.WriteLine("Scenario " + nameof(scenario02) + " has begun.");
            scenario02.Run();
            Console.WriteLine(Scenario.totalTime.ToString());
        }
    }
}
