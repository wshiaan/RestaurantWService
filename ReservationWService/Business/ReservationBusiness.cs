using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReservationWService.Domain;
using ReservationWService.DataAccess;
using System.Collections;

namespace ReservationWService.Business
{
    public class ReservationBusiness
    {
        private readonly ReservationDataAccess reservationDataAccess;


        public ReservationBusiness()
        {
            reservationDataAccess = new ReservationDataAccess();
        }

        public List<RestaurantName> GetRestaurantName()
        {
            return reservationDataAccess.GetRestuarantName();
        }

        public void InsertDetails(string bookname, string phoneno, string email,
            string bookstart, string bookend, int headcount)
        {
            reservationDataAccess.InsertDetails(bookname, phoneno, email, bookstart, bookend, headcount);
        }

        public void InsertBooking(int tableid, DateTime confirmdate,string status)
        {
            reservationDataAccess.InsertBooking(tableid, confirmdate,status);
        }

        public List<TableNo> GetTableNo(int restaurantid, string bookstart, string bookend, int headcount)
        {

            return reservationDataAccess.GetTableNo(restaurantid, bookstart, bookend, headcount);
        }

        public bool CheckTime(int restaurantid, DateTime bookstart, DateTime bookend)
        {
            return reservationDataAccess.CheckTime(restaurantid, bookstart, bookend);
        }
    }
}