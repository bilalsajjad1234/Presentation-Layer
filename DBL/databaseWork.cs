using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DBL
{
    public class databaseWork
    {
        public SqlConnection connection;
        public string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public bool customerExistence(string username, string password)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("exec checkCustomer @Username, @Password", connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        public bool managerExistence(string username, string password)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("exec checkManager @Username, @Password", connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }



        }

        //ye pata lagaega user type kia ha manager ha ya customer

        public string getUserType(string username, string password)
        {
            if (customerExistence(username, password))
            {
                return "Customer";

            }
            else if (managerExistence(username, password))
            {
                return "Manager";
            }
            return "unknown";





        }

        public bool insertUser(int id, string name, string username, string password, string contact)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("insertCustomer @id, @name, @username, @password, @contact", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@contact", contact);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }








        //check if room already in table

        public bool searchRoom(int rid)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("countRoomsByRoomId @roomid", connection))
                {
                    command.Parameters.AddWithValue("@roomid", rid);
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }

            }


        }






        public bool addRoomsData(int rid, int rprice, int cap, string type)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("insertSpringsRoom @rid, @rprice, @cap, @rtype", connection))
                {
                    command.Parameters.AddWithValue("@rid", rid);
                    command.Parameters.AddWithValue("@rprice", rprice);
                    command.Parameters.AddWithValue("@cap", cap);
                    command.Parameters.AddWithValue("@rtype", type);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
        }





        //viewing sare rooms

        public DataTable getRooms()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("viewRooms", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                    }
                }

            }
            return datatable;


        }






        public bool isRoomBook(int rid)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("checkBookedRoomExists @roomid", connection))
                {
                    command.Parameters.AddWithValue("@roomid", rid);
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }

            }


        }





        //check if room is there or not 
        public bool isRoomPresent(int rid)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("checkRoomPresent @roomid", connection))
                {
                    command.Parameters.AddWithValue("@roomid", rid);
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }

            }


        }






        //ifusername booked already
        public bool isUserBooked(string name)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("checkUserBooked @name", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }

            }


        }





        //bookedroomsadding

        public bool bookedInsert(string name, int roomno, int days)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("insertBookedRoom @name, @roomno, @days", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@roomno", roomno);
                    command.Parameters.AddWithValue("@days", days);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
        }








        //customer checkin confirm krna ha bhai

        public bool customerConfirm(string username)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("countBookedRoomsByUsername @Username", connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }




        }



        //din lelo 



        public int gettingDays(string username)
        {
            string query = "getNoOfDaysByName @name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", username);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }

        }




        //getting price

        public int gettingPrice(int id)
        {
            string query = "getPriceByRoomId @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }

        }




        //getting roomno

        public int getRoomno(string username)
        {
            string query = "getRoomNoByName @name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", username);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }

        }







        public DataTable getFood()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("getFood", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                    }
                }

            }
            return datatable;



        }






        //getting food price

        public int getFoodPrice(int id)
        {
            string query = "SELECT price FROM hotelfoods WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }

        }







        //updating the price 

        public bool updatePrice(int rid, int price)
        {
            string updateQuery = $"UPDATE springsroom SET price = price + {price} WHERE rmid = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", rid);

                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }


        }


        public bool checkingPin(int pin)
        {
            string query = $"select count(*) from pins where pin = @pin";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@pin", pin);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }




        //deleting customer in booked room


        public bool deleteCustomer(string name)
        {
            string q = $"delete from bookedroom where namee = @name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand cmd = new SqlCommand(q,connection))
                {
                    cmd.Parameters.AddWithValue("name",name);
                    int rowsAff = cmd.ExecuteNonQuery();
                    return rowsAff > 0; 

                }
            }
        }



        ///fooods daldo thory see
        ///


        public bool addFood(int id,string name,int price)
        {
            string q = $"insert into hotelfoods(id,namee,price) VALUES (@id, @name, @price)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(q,connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    int rowsAff = cmd.ExecuteNonQuery();
                    return rowsAff > 0;

                }
            }
        }



        ///food delete krwao
        public bool deleteFood(int id)
        {
            string q = $"delete from hotelfoods where id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(q, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAff = cmd.ExecuteNonQuery();
                    return rowsAff > 0;

                }
            }
        }


        //updating food now


        public bool updateFood(int id,int price)
        {
            string q = $"update hotelfoods set price = @price where id= @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(q, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@price", price);
                    int rowsAff = cmd.ExecuteNonQuery();
                    return rowsAff > 0;

                }
            }
        }




    }

}