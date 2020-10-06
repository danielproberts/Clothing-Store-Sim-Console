using System;
using System.Collections.Generic;
using System.Text;

namespace Daniel_Roberts_Unit6_IT481
{
    class Room
    {
        public int roomNumber;
        public int roomInUse;
        public List<int> timeRoomInUse = new List<int>();

        public Room(int num)
        {
            roomNumber = num + 1;
            roomInUse = 0;
        }
    }
}
