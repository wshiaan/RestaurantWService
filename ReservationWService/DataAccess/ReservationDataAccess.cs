using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ReservationWService.Domain;
using ReservationWService.Business;
using System.Collections;

namespace ReservationWService.DataAccess
{
    public class ReservationDataAccess
    {
        public ReservationDataAccess()
        {
        }

        public List<RestaurantName> GetRestuarantName()
        {
            List<RestaurantName> restaurantName = new List<RestaurantName>();
            using (
                    var connection = new SqlConnection("Data Source=192.168.56.1\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;")
                //Server=.\\SQLEXPRESS;Database=RestaurantReservation;Trusted_Connection=True;MultipleActiveResultSets=true;
                //Data Source=.\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;
                //192.168.56.1
                //PBF93Y1\SQLEXPRESS (SW\wxl702) Trusted_Connection=True;MultipleActiveResultSets=true;"
                // "Data Source=//10.11.48.85/xe;User ID=fe_user_data;Password=fe_user_data;Max Pool Size=5;Min Pool Size=0;"
                          )
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQLStatements.RestaurantName.GetRestaurantName;
                    command.Connection = connection;
                    connection.Open();


                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            var restaurant = new RestaurantName(Convert.ToInt32(reader["RestaurantID"].ToString()),
                                                               reader["RestaurantName"].ToString());


                            restaurantName.Add(restaurant);
                        }
                    }
                    connection.Close();

                }
                return restaurantName;
            }

        }

        /*
        public ArrayList GetRestaurantName()
        {
            ArrayList restaurantName = new ArrayList();
            int count = 0;
            using (
                    var connection = new SqlConnection("Data Source=192.168.56.1\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;")
                //Server=.\\SQLEXPRESS;Database=RestaurantReservation;Trusted_Connection=True;MultipleActiveResultSets=true;
                //Data Source=.\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;
                //192.168.56.1
                //PBF93Y1\SQLEXPRESS (SW\wxl702) Trusted_Connection=True;MultipleActiveResultSets=true;"
                // "Data Source=//10.11.48.85/xe;User ID=fe_user_data;Password=fe_user_data;Max Pool Size=5;Min Pool Size=0;"
                          )
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQLStatements.RestaurantName.GetRestaurantName;
                    command.Connection = connection;
                    connection.Open();


                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                count += 1;
                                var restaurant = new RestaurantName(Convert.ToInt32(reader["RestaurantID"].ToString()),
                                                                   reader["RestaurantName"].ToString());


                                restaurantName.Add(restaurant);
                            }

                        }

                    }
                    connection.Close();

                }
                return restaurantName;
            }
        }
         
         */

        public void InsertDetails(string bookname, string phoneno, string email,string bookstart, string bookend, int headcount)
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            using (
                    var connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;")
                  )
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQLStatements.UserDetails.GetUserDetails;
                    //command.Parameters.AddWithValue("@UserID", userid);
                   // command.Parameters.AddWithValue("@BookingID", bookid);
                    command.Parameters.AddWithValue("@BookName", bookname);
                    command.Parameters.AddWithValue("@PhoneNo", phoneno);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@BookStart", bookstart);
                    command.Parameters.AddWithValue("@BookEnd", bookend);
                    command.Parameters.AddWithValue("@Headcount", headcount);
                    

                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();

                }
            }
        }

        public void InsertBooking(int tableid, DateTime confirmdate, string status)
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            using (
                    var connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;")
                  )
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQLStatements.BookingDetails.GetBookingDetails;
                    //command.Parameters.AddWithValue("@UserID", userid);
                    //command.Parameters.AddWithValue("@BookingID", bookid);
                    command.Parameters.AddWithValue("@TableID", tableid);
                    command.Parameters.AddWithValue("@ConfirmationDate", confirmdate);
                   // command.Parameters.AddWithValue("@ConfirmationTime", confirmtime.ToShortTimeString());
                    command.Parameters.AddWithValue("@Status", status);


                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();

                }
            }
        }

        public List<TableNo> GetTableNo(int restaurantid, string  bookstart, string bookend, int headcount)
        {

            List<TableNo> tableNo = new List<TableNo>();
            using (
                    var connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;")
                  )
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQLStatements.TableNo.GetTableNo;
                    command.Connection = connection;
                    connection.Open();
                    command.Parameters.AddWithValue("@RestaurantID", restaurantid);
                    command.Parameters.AddWithValue("@BookStart", bookstart);
                    command.Parameters.AddWithValue("@Headcount", headcount);
                    command.Parameters.AddWithValue("@BookEnd", bookend);
                    


                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tablenum = new TableNo(Convert.ToInt32(reader["TableID"].ToString()), Convert.ToInt32(reader["TableNo"].ToString()));


                            tableNo.Add(tablenum);
                        }
                        
                    }
                    connection.Close();
                   
                }
                return tableNo;
            }
        }

        public bool CheckTime(int restaurantid, DateTime bookstart, DateTime bookend)
        {
            using (
                    var connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=RestaurantReservation;Integrated Security=SSPI;")
                  )
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQLStatements.CheckTime.IsWorkingHour;
                    command.Connection = connection;
                    connection.Open();
                    command.Parameters.AddWithValue("@RestaurantID", restaurantid);
                    command.Parameters.AddWithValue("@Bookstart", bookstart);
                    command.Parameters.AddWithValue("@Bookend", bookend);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return true;
                    }
                    connection.Close();
                }
            }

            return false;
        }
    }
}