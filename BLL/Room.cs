using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBL;

namespace BLL
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }

    }
    public class DeluxeRoom : Room
    {
        public string HasJacuzzi { get; set; }

    }
    public class StandardRoom : Room
    {
        public string HasBalcony { get; set; }

    }
}
