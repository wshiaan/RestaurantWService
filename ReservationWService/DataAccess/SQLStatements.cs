using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationWService.DataAccess
{
    public struct SQLStatements
    {
        public struct RestaurantName
        {
            public static readonly string GetRestaurantName = "select RestaurantID, RestaurantName " +
                "from Restaurant " +
                "order by RestaurantName asc ";
        }

        public struct UserDetails
        {
            public static readonly string GetUserDetails = "declare @newuserid int " +
              "set @newuserid= (select max(UserID)+1 from Booking) "+
              "insert into Userdetails " +
                "values(@newuserid,@newuserid,@BookName,@PhoneNo,@Email,cast(@BookStart as datetime),cast(@BookEnd as datetime),@Headcount);";
        }

        public struct BookingDetails
        {
            public static readonly string GetBookingDetails = "declare @newbookid int " +
              "set @newbookid= (select max(BookingID) from Userdetails) " +
              "insert into Booking " +
                "values(@newbookid,@newbookid,@TableID,CAST(@ConfirmationDate AS date),CAST(@ConfirmationDate AS time),@Status)";
        }

        public struct TableNo
        {
            public static readonly string GetTableNo =
                "select t.TableID,t.TableNo " +
                 "from Restaurant r inner join Tablelist t " +
                 "on t.RestaurantID=r.RestaurantID " +
                 "where t.RestaurantID=@RestaurantID " +
                "AND t.Headcount>= @Headcount " +
                 "AND t.TableID " +
                 "NOT IN ( " +
                     "select b.TableID as TableJoin " +
                     "from Userdetails ud INNER JOIN Booking b " +
                     "on ud.BookingID=b.BookingID " +
                     "where @BookStart > BookStart " +
                        "AND @BookStart < BookEnd) ";

        }

        public struct CheckTime
        {
            public static readonly string IsWorkingHour =
            " SELECT * FROM Restaurant " +
            " WHERE RestaurantID=@RestaurantID " +
            "AND (CAST(@Bookstart AS TIME) > StartTime and CAST( @Bookstart AS TIME) < EndTime) " +
            "AND (CAST(@Bookend AS TIME) > StartTime and CAST(@Bookend AS TIME) < EndTime) ";

        }
    }
}