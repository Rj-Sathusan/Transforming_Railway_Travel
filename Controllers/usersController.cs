using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TRY.Models;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace TRY.Controllers
{
    public class usersController : Controller
    {
        private readonly WebApi.Helpers.ApplicationDbContext _context;
    

        public usersController(WebApi.Helpers.ApplicationDbContext context)
        {
            _context = context;
        }


      public  JsonResult user(string Name,string NIC,string Gmail,string Password)
        {
       
        
       var users= _context.Database.ExecuteSqlRaw("INSERT INTO user (Name, NIC, Gmail, Password) VALUES ({0}, {1}, {2}, {3})",
                Name, NIC, Gmail, Password);


       return new JsonResult(Ok(users));
        }



// public  JsonResult Login(string Gmail,string Password)
//         {
            
//        var query = "SELECT * FROM user WHERE Gmail = {0} AND Password = {1}";
//             var users = _context.user.FromSqlRaw(query, Gmail, Password).ToList();

//             if (users.Count > 0)
//             {
//                 return new JsonResult(users);
//             } 

            // return new JsonResult("No user");
//         }
        
public JsonResult Login(string Gmail, string Password)
{
    var query = "SELECT * FROM user WHERE Gmail = @p0 AND Password = @p1";
    var users = _context.user.FromSqlRaw(query, Gmail, Password).ToList();

    if (users.Count > 0)
    {
        return new JsonResult(users);
    }

    return new JsonResult("No user");
}

        
  
     
        // GET: users
        public async Task<IActionResult> Index()
        {
           
              return View(Index);
        }


   public IActionResult FrontPage(string id, string nic, string Loyalty)
{
    ViewBag.UserId = id; // Pass the id to the view using ViewBag
    ViewBag.UserLoyalty = Loyalty;
    ViewBag.UserNIC = nic;

    return View(FrontPage);
}

    
      



        

      


        // GET: users/Details/5
        [HttpPost] 
        public async Task<IActionResult> Details(int? id)
        {
           

            return View(user);
        }


    


       
      
    }
}
