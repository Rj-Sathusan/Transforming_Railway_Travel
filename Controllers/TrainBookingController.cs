using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TRY.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Mail;

namespace TRY.Controllers
{
    public class TrainBookingController : Controller
    {
        private readonly WebApi.Helpers.ApplicationDbContext _context; // Make sure this is of type DbContext or a derived class

        public TrainBookingController(WebApi.Helpers.ApplicationDbContext context)
        {
            _context = context;
        }

        
public  JsonResult booking(string user_id,string loyalty,string loyalty_statues,string train_id,string date,string final_price,string time)
        {
       
            var query ="SELECT * FROM income_details WHERE user_ID = {0}";
                   var incomeDetail = _context.income_details.FromSqlRaw(query,user_id).ToList();

      // return new JsonResult(loyalty);

        if (incomeDetail.Count <= 0 )
            {
                // User does not exist, create a new record
                _context.Database.ExecuteSqlRaw("INSERT INTO income_details (user_ID, total_Income, discount) VALUES ({0}, {1}, {2})", user_id, final_price, loyalty);
            }


        else
            {
                // User exists, update the Total_Income with the final_price
                               _context.Database.ExecuteSqlRaw("UPDATE income_details SET Total_Income = total_Income + {0}, discount = discount + {1} WHERE user_ID = {2}", final_price,loyalty, user_id);

                _context.Database.ExecuteSqlRaw("UPDATE user SET Loyalty = loyalty - ({0}*10) +100  WHERE id = {1}",loyalty, user_id);
            }



       var users= _context.Database.ExecuteSqlRaw("INSERT INTO trainbooking (user_id, loyalty, train_id, final_price,date,time) VALUES ({0}, {1}, {2}, ({3} - {5}),{4},{6})",
                user_id, loyalty_statues, train_id, final_price,date,loyalty,time);

        var maxId = _context.TrainBooking.Max(tb => tb.id);
        int user_id0 = int.Parse(user_id);

            var _id = _context.user.FirstOrDefault(u => u.id == user_id0);

       return new JsonResult(Ok(_id.Gmail));
        }
 


// public IActionResult GetBookingDetails(int referenceNumber)
// {
//     var sql = @"
//       SELECT tb.*, u.Name, t.train_name, t._from, t._to FROM trainbooking tb INNER JOIN user u ON tb.user_id = u.Id INNER JOIN train_details t ON tb.train_id = t.Id WHERE tb.Id = {0}";

//     var bookingDetails = _context.TrainBooking.FromSqlRaw(sql, referenceNumber).FirstOrDefault();

//     if (bookingDetails == null)
//     {
//         return NotFound(); // Return 404 if the booking with the given reference number is not found
//     }



//     return Json(bookingDetails);
// }
public IActionResult GetBookingDetails(int referenceNumber)
{
    //   var sql = "CALL GetBookingDetails(@referenceNumber)";

    // var parameter = new MySql.Data.MySqlClient.MySqlParameter("@referenceNumber", referenceNumber);

    // var bookingDetails = _context.TrainBooking
    //     .FromSqlRaw(sql, parameter)
    //     .FirstOrDefault();

    // if (bookingDetails == null)
    // {
    //     return NotFound(); // Return 404 if the booking with the given reference number is not found
    // }

    // var result = new
    // {
    //     UserName = bookingDetails.User.Name,
    //     TrainName = bookingDetails.train_details.train_name,
    //     From = bookingDetails.train_details._from,
    //     To = bookingDetails.train_details._to
    // };

            var users = _context.BookingDetails. FromSqlRaw("CALL GetBookingDetails ({0})",referenceNumber).ToList();


    return Json(users);
}














           public IActionResult FrontPage()
        {
            //  ViewBag.Name = Name;
            
            //  ViewBag.EmployeeName = id;
    //     // //specify the name or path of the part
            
            //  ViewBag.Address = Address;

            
              return View(FrontPage);
        }


       // Action method to retrieve and console write all data from TrainBooking table
        public IActionResult GetAllTrainBookings()
        {
            try
            {
                var bookings = _context.TrainBooking.ToList();

                return Json(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
    }
}
