using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationWService.Domain
{
    public class BookingDetails
    {
        public BookingDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public BookingDetails(int bookingid, int userid, int tableid, DateTime confirmationdate, DateTime confirmationtime, string status)
        {
            Bookingid = bookingid;
            Userid = userid;
            Tableid = tableid;
            Confirmationdate = confirmationdate;
            Confirmationtime = confirmationtime;
            Status = status;
        }

        public int Bookingid { get; set; }
        public int Userid { get; set; }
        public int Tableid { get; set; }
        public DateTime Confirmationdate { get; set; }
        public DateTime Confirmationtime { get; set; }
        public string Status { get; set; }
    }
}