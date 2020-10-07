using System;
using System.Collections.Generic;
using System.Text;

namespace Daniel_Roberts_Unit6_IT481
{
    class Customer
    {
        public int numberOfItems;
        public int timeInDressingRoom;
        public int customerNumber;
        public int roomNumber;
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
            //DressingRooms.RequestRoom(this);
            int clothingItems = this.numberOfItems;
            Console.WriteLine("Customer #" + this.customerNumber + " has entered Dressing Room# " + this.roomNumber);
            Console.WriteLine("Customer #" + this.customerNumber + " is trying on " + this.numberOfItems + " items.");
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
