using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TRY.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TRY.Controllers
{
    public class TrainBookingController : Controller
    {
        private readonly WebApi.Helpers.ApplicationDbContext _context; // Make sure this is of type DbContext or a derived class

        public TrainBookingController(WebApi.Helpers.ApplicationDbContext context)
        {
            _context = context;
        }

        
public  JsonResult booking(string user_id,string loyalty,string train_id,string date,string final_price)
        {
       
        
       var users= _context.Database.ExecuteSqlRaw("INSERT INTO trainbooking (user_id, loyalty, train_id, final_price,date) VALUES ({0}, {1}, {2}, {3},{4})",
                user_id, loyalty, train_id, final_price,date);


       return new JsonResult(Ok(users));
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
