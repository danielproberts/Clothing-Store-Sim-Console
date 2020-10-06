using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Daniel_Roberts_Unit6_IT481
{
    class DressingRooms
    {
        //Class Parameters
        public int numOfRooms { get; set; }
        public Semaphore availableRooms;
        public List<Room> roomsList;
        public DressingRooms()
        {
            numOfRooms = 3;
            roomsList = new List<Room>(numOfRooms);
            availableRooms = new Semaphore(0, numOfRooms);
        }

        public DressingRooms(int num)
        {
            numOfRooms = num;
            roomsList = new List<Room>(numOfRooms);
            availableRooms = new Semaphore(0, numOfRooms);
        }

        public static int RequestRoom(DressingRooms rooms)
        {
            rooms.availableRooms.WaitOne();
            for (int i = 0; i <= rooms.roomsList.Capacity; i++)
            {
                if (rooms.roomsList[i].roomInUse == 0)
                {
                    Console.WriteLine("Test " + i.ToString());
                    rooms.roomsList[i].roomNumber = i + 1;
                    rooms.roomsList[i].roomInUse = 1;
                    return rooms.roomsList[i].roomNumber;
                }
            }
            return -1;
        }

    }

}

/*DressingRooms will be a class, and there will only be one instance of DressingRooms.

The default constructor will use three rooms as the default.
The constructor takes a parameter that sets the number of rooms available.
Use a semaphore object to control access to the rooms.
Supply a public RequestRoom() method that the customer will use to gain access.
A RequestRoom method waits for an available room.
*/
