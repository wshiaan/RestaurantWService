using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationWService.Domain
{
    public class UserDetails
    {
        public UserDetails()
        {
        }

        public UserDetails(int userid, int bookid, string bookname, string phoneno, string email,
            DateTime bookstart, DateTime bookend, int headcount)
        {
            Userid = userid;
            Bookid = bookid;
            Bookname = bookname;
            Phoneno = phoneno;
            Email = email;
            Bookstart = bookstart;
            Bookend = bookend;
            Headcount = headcount;
           

        }

        public int Userid { get; set; }
        public int Bookid { get; set; }
        public string Bookname { get; set; }
        public string Phoneno { get; set; }
        public string Email { get; set; }
        public DateTime Bookstart { get; set; }
        public DateTime Bookend { get; set; }
        public int Headcount { get; set; }
        
    }
}