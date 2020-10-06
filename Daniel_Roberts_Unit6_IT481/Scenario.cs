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
        public static List<Room> roomsList = new List<Room>();
        //public static int[,] roomsData = new int[,] { };

        public Scenario(int rooms, int customers)
        {
            dressingRooms = new DressingRooms(rooms);
            numOfCustomers = customers;
            dressingRooms.numOfRooms = rooms;
            //Creates an Array of Rooms. First index shows
            //status of Room (0 - Empty, 1 - Occupied)
            //Second index will be an array of the times each 
            //Customer spent in the Room.
            dressingRooms.roomsList.Capacity = dressingRooms.numOfRooms;

            //Array.Resize(roomsData[0,0], dressingRooms.numOfRooms);
            for (int i = 0; i < dressingRooms.numOfRooms; i++)
            {
                Room emptyRoom = new Room(i);
                dressingRooms.roomsList.Add(emptyRoom);
            }
            for (int i = 1; i <= numOfCustomers; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Customer));
                t.Start(i);
                //Console.WriteLine("Customer #" + i + " is waiting for a dressing room.");
                Thread.Sleep(500);
            }
            //Thread.Sleep(1000);
            dressingRooms.availableRooms.Release(dressingRooms.numOfRooms);
        }

        public static int RequestRoom(DressingRooms rooms)
        {
            rooms.availableRooms.WaitOne();
            for(int i = 0; i <= rooms.roomsList.Capacity; i++)
            {
                if(rooms.roomsList[i].roomInUse == 0)
                {
                    Console.WriteLine("Test " + i.ToString());
                    rooms.roomsList[i].roomNumber = i + 1;
                    rooms.roomsList[i].roomInUse = 1;
                    return rooms.roomsList[i].roomNumber;
                }
            }
            return -1;
        }

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
    }
}
