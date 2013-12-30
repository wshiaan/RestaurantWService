using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ReservationWService.DataAccess;
using ReservationWService.Business;
using ReservationWService.Domain;
using System.Collections;


namespace ReservationWService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class ReservationWebService : System.Web.Services.WebService
    {
        public ReservationWebService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
        /*
        [WebMethod]
        public string HelloWorld() {
            return "Hello World";
        }
        */
        private ReservationBusiness reservationBusiness;

        [WebMethod]
        public List<RestaurantName> GetRestaurantName()
        {
            reservationBusiness = new ReservationBusiness();
            return reservationBusiness.GetRestaurantName();
        }

        [WebMethod]
        public void InsertDetails(string bookname, string phoneno, string email,
            string bookstart, string bookend, int headcount)
        {
            reservationBusiness = new ReservationBusiness();
            reservationBusiness.InsertDetails(bookname, phoneno, email, bookstart, bookend, headcount);

        }

        [WebMethod]
        public void InsertBooking(int tableid, DateTime confirmdate, string status)
        {
            reservationBusiness = new ReservationBusiness();
            reservationBusiness.InsertBooking(tableid, confirmdate,status);

        }

        [WebMethod]
        public List<TableNo> GetTableNo(int restaurantid, string bookstart, string bookend, int headcount)
        {
            reservationBusiness = new ReservationBusiness();
            return reservationBusiness.GetTableNo(restaurantid, bookstart, bookend, headcount);
        }

        [WebMethod]
        public bool CheckTime(int restaurantid, DateTime bookstart, DateTime bookend)
        {
            reservationBusiness = new ReservationBusiness();
            return reservationBusiness.CheckTime(restaurantid, bookstart, bookend);
        }
    }
}