using System;
using System.Collections.Generic;
using System.Text;

namespace Daniel_Roberts_Unit6_IT481
{
    class Customer
    {
        public int numberOfItems;
        public static int timeInDressingRoom;
        public int customerNumber;
        public Customer()
        {
            Random rand = new Random();
            int r = rand.Next(1, 7);
            numberOfItems = r;
            Console.WriteLine("Customer Created");
        }
        public Customer (int num)
        {
            numberOfItems = num;
        }

        public void TryOnClothes()
        {
            int clothingItems = this.numberOfItems;

            for (int i = 0; i < clothingItems; i++)
            {
                Random randTryOn = new Random();
                int tryOnClothes = randTryOn.Next(1, 4);
                timeInDressingRoom += tryOnClothes;
            }
            Console.WriteLine(timeInDressingRoom.ToString());
        }
    }
}
