using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationWService.Domain
{
    public class TableNo
    {
        public TableNo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public TableNo(int tableid, int tableno)
        {
            Tableid = tableid;
            TableNum = tableno;

        }
        public int TableNum { get; set; }
        public int Tableid { get; set; }
    
    }
}