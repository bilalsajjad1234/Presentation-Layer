using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBL;

namespace BLL
{

    public class Receptionist
    {
        DBL.databaseWork db = new databaseWork();

        public bool ifRoom(int rno)
        {
            return db.searchRoom(rno);
        }
        public bool addRoom(int rno, int rprice, int cap, string type)
        {
            if (ifRoom(rno))
            {
                return false;
                


            }
            else
            {
                return db.addRoomsData(rno, rprice, cap, type);
            }
        }





        public DataTable fetchRooms()
        {

            return db.getRooms();

        }








        public bool roomCheck(int rno)
        {
            return db.isRoomBook(rno);
        }
        public bool roomPresent(int rno)
        {
            return db.isRoomPresent(rno);
        }

        public bool alreadyBook(string name)
        {
            return db.isUserBooked(name);
        }







        public bool addBookedRoom(string name, int roomno, int days)
        {
            return db.bookedInsert(name, roomno, days);

        }





        public bool getCustomerCheckinDetail(string username)
        {
            return db.customerConfirm(username);
        }








        public int getDays(string username)
        {
            return db.gettingDays(username);
        }

        public int getPrice(int id)
        {
            return db.gettingPrice(id);
        }

        public int getRoom(string username)
        {
            return db.getRoomno(username);
        }






        public DataTable fetchfood()
        {

            return db.getFood();

        }



        public bool priceUpdate(int rid, int price)
        {
            return db.updatePrice(rid, price);
        }




        public int getPriceofFood(int id)
        {
            return db.getFoodPrice(id);
        }



        public bool delCus(string name)
        {
            return db.deleteCustomer(name);
        }





        public bool addFood(int id,string name,int price)
        {
            return db.addFood(id, name, price);
        }




        public bool delFood(int id)
        {
            return db.deleteFood(id);
        }



        public bool updateFood(int id,int price)
        {
            return db.updateFood(id,price);
        }















    }
}
