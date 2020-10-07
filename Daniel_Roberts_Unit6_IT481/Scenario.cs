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
        public List<Room> roomsList;

        public Scenario(int numOfRooms, int customers)
        {
            dressingRooms = new DressingRooms(numOfRooms);
            numOfCustomers = customers;
            customerList = new List<Customer>();
            roomsList = new List<Room>();
            for (int i = 0; i < numOfCustomers; i++)
            {
                Customer c = new Customer();
                c.customerNumber = i + 1;
                customerList.Add(c);
            }
            for (int i = 0; i <= numOfRooms; i++)
            {
                Room r = new Room();
                roomsList.Add(r);
                r.roomNumber = i + 1;
            }
            Console.WriteLine("Number of Customers: " + customerList.Count);
            Console.WriteLine("Number of Rooms: " + roomsList.Count);
            foreach(Room r in roomsList)
            {
                Console.WriteLine(r.roomNumber + " " + r.roomInUse.ToString());
            }
        }

        public void Run()
        {
            dressingRooms.availableRooms.Release(dressingRooms.numOfRooms);
            foreach (Customer c in customerList)
            {
                //dressingRooms.RequestRoom(c, this);
                Thread t = new Thread(() => c.TryOnClothes());
                t.Start();
                Console.WriteLine("Customer #" + c.customerNumber + " is waiting for a dressing room.");
                Thread.Sleep(500);
                //this.roomsList[c.roomNumber-1].timeRoomInUse.Add(c.timeInDressingRoom);
            }
        }
    }
}
