using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TRY.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TRY.Controllers
{
    public class train_detailsController : Controller
    {
        private readonly WebApi.Helpers.ApplicationDbContext _context; // Make sure this is of type DbContext or a derived class

        public train_detailsController(WebApi.Helpers.ApplicationDbContext context)
        {
            _context = context;
        }

        
public JsonResult Availability(string to, string from)
{
   var query = _context.train_details
                .Where(t => t._to == to && t._from == from && t.time01 != null )
                .Select(t => new { Time1 = t.time01, Time2 = t.time02 })
                .ToList();

            if (query.Count > 0)
            {
                return new JsonResult(query);
            }

            return new JsonResult(null);
        }

        
    }
}
