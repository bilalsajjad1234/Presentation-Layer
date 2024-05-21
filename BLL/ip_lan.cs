using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DBL;

namespace BLL
{
    public class ip_lan
    {

        databaseWork db = new databaseWork();


 

        static RegistryKey basefolder = Registry.CurrentUser;
        static string subfolderpath = "bilaldummy";
        static string keyname = "billu";
        public bool ConnectToDatabase(string ipAddress, string username, string password)
        {
            try
            {
               
                return db.Connect(ipAddress, username, password);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        public List<string> GetDatabaseList(string ipAddress, string username, string password)
        {
           
            return db.GetDatabaseList(ipAddress, username, password);
        }


        public void registrywrite(string ip)
        {
            RegistryKey regkey = basefolder;
            RegistryKey subkey = regkey.CreateSubKey(subfolderpath);
            subkey.SetValue(keyname, ip);

        }
        public string registryread()
        {
            RegistryKey regkey = basefolder;
            RegistryKey subkey = regkey.OpenSubKey(subfolderpath);
            if (subkey != null)
            {
                return subkey.GetValue(keyname)?.ToString();
            }
            else
            {
                Console.WriteLine("Subkey not found.");
                return null;
            }
        }


    
}
}
