using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationWService.Domain
{
    public class RestaurantName
    {
        public RestaurantName()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public RestaurantName(int resid, string resname)
        {
            Resid = resid;
            Resname = resname;
        }

        public int Resid { get; set; }

        public string Resname { get; set; }

       
    }
    }
