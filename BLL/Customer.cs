using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBL;
using System.Threading.Tasks;


namespace BLL
{
    public class Customer
    {
        DBL.databaseWork db = new databaseWork();
        public string whichUserType(string username, string password)
        {
            return db.getUserType(username, password);
        }

        public bool thisCustomerAdded(int id, string name, string username, string password, string contact)
        {
            return db.insertUser(id, name, username, password, contact);

        }
    }

    public static class user
    {
        public static string Username { get; set; }
    }
}
