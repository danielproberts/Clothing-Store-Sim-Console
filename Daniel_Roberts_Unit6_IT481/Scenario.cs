using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace Daniel_Roberts_Unit6_IT481
{
    class Scenario
    {
        public static int timePassed = 0;
        public static int timeWaiting = 0;
        public static DressingRooms dressingRooms;
        public int numOfCustomers;
        public static int totalTime = 0;
        public List<Customer> customerList;
        //public static List<Room> roomsList = new List<Room>();
        //public static int[,] roomsData = new int[,] { };

        public Scenario(int numOfRooms, int customers)
        {
            dressingRooms = new DressingRooms(numOfRooms);
            numOfCustomers = customers;
            customerList = new List<Customer>();
            Console.WriteLine(customerList.Count);
            for (int i = 0; i < numOfCustomers; i++)
            {
                Customer c = new Customer();
                customerList.Add(c);
                c.customerNumber = i + 1;
            }
            Console.WriteLine(customerList.Count);


            //for (int i = 0; i < customerList.Count; i++)
            
            //Thread.Sleep(1000);
            dressingRooms.availableRooms.Release(dressingRooms.numOfRooms);
        }

        public void Run()
        {
            foreach (Customer c in customerList)
            {
                //int num = customerList[i].numberOfItems;
                Thread t = new Thread(() => c.TryOnClothes());
                //Thread t = new Thread(new ParameterizedThreadStart());
                t.Start();
                Console.WriteLine("Customer #" + c.customerNumber + " is waiting for a dressing room.");
                Thread.Sleep(500);
            }
            //Console.WriteLine("Scenario " + nameof(this) + " has begun.");
        }

        
        /*
        public static void Customer(object num)
        {
            //Random randSleep = new Random();
            //Thread.Sleep(randSleep.Next(1000, 2000));
            int roomNumber = RequestRoom(dressingRooms);
            Console.WriteLine("Customer #" + num + " has entered Room#" + roomNumber);
            //timeWaiting = timePassed;
            timeWaiting = totalTime;
            Console.WriteLine("Customer #" + num + " waited " + timeWaiting + "min for a Dressing Room");
            int numberOfItems = (int)num;
            int clothingItems;
            int timeInDressingRoom = 0;
            if (numberOfItems == 0)
            {
                Random rand = new Random();
                int r = rand.Next(1, 7);
                clothingItems = r;
            }

            else if (numberOfItems < 21)
            {
                clothingItems = numberOfItems;
            }

            else
            {
                clothingItems = 20;
            }

            for (int i = 0; i < clothingItems; i++)
            {
                Random randTryOn = new Random();
                int tryOnClothes = randTryOn.Next(1, 4);
                timeInDressingRoom += tryOnClothes;
            }

            Console.WriteLine("Time in Dressing Room: " + timeInDressingRoom.ToString());
            timePassed = timeInDressingRoom;
            dressingRooms.roomsList[roomNumber-1].roomInUse = 0;
            dressingRooms.availableRooms.Release();
            totalTime += timeInDressingRoom;
        }
        */
    }
}
