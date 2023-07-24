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

  public IActionResult FrontPage()
{
    return View("front_page"); // Assuming "FrontPage" is the name of your .cshtml file
}
public  JsonResult Login(string Gmail,string Password)
        {
            
       var query = "SELECT * FROM user WHERE Gmail = {0} AND Password = {1}";
            var users = _context.user.FromSqlRaw(query, Gmail, Password).ToList();

            if (users.Count > 0)
            {
                return new JsonResult("Yes");
            } 

            return new JsonResult("No user");
        }
        

        
  
     
        // GET: users
        public async Task<IActionResult> Index()
        {
            // List<user> cl = new List<user>();  
            //  cl = (from c in _context.user select c).ToList();  
            // cl.Insert(0, new user { id = 0, Name = "--Select Country Name--" });  
            // ViewBag.message = cl;  
           
              //return View(await _context.user.ToListAsync());
              return View(Index);
        }


        public IActionResult Create(string Name)
        {
            //  ViewBag.Name = Name;
            
            //  ViewBag.EmployeeName = id;
    //     // //specify the name or path of the part
            
            //  ViewBag.Address = Address;

            
              return View("Create");
        }

    
        [HttpGet]
       public  JsonResult sql(int id)
        {
        // var users=  _context.user.FirstOrDefault(m => m.id == id);
        //var users=  _context.user.FromSqlRaw("select * from user").ToList();
        
        var users = _context.user. FromSqlRaw("CALL GET ({0})",id).ToList();


       return new JsonResult(Ok(users));
        }




        

        // public IActionResult db_value (string Name)
        // {
        //       return View("Create");
        // }



        // GET: users/Details/5
        [HttpPost] 
        public async Task<IActionResult> Details(int? id)
        {
            // if (id == null || _context.user == null)
            // {
            //     return NotFound();
            // }

            // var user = await _context.user
            //     .FirstOrDefaultAsync(m => m.id == id);
            // if (user == null)
            // {
            //     return NotFound();
            // }

            return View(user);
        }


    


        // GET: users/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Name,id,Address")] user user)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(user);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(user);
        // }

        // GET: users/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null || _context.user == null)
        //     {
        //         return NotFound();
        //     }

        //     var user = await _context.user
        //         .FirstOrDefaultAsync(m => m.id == id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(user);
        // }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,id,Address")] user user)
        {
            // if (id != user.id)
            // {
            //     return NotFound();
            // }

            // if (ModelState.IsValid)
            // {
            //     try
            //     {
            //         _context.Update(user);
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!userExists(user.id))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }
            //     return RedirectToAction(nameof(Index));
            // }
            return View(user);
        }

        // GET: users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
        //    if (_context.user == null)
        //     {
        //         return Problem("Entity set 'ApplicationDbContext.user'  is null.");
        //     }
        //     var user = await _context.user.FindAsync(id);
        //     if (user != null)
        //     {
        //         _context.user.Remove(user);
        //     }
            
        //     await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: users/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     if (_context.user == null)
        //     {
        //         return Problem("Entity set 'ApplicationDbContext.user'  is null.");
        //     }
        //     var user = await _context.user.FindAsync(id);
        //     if (user != null)
        //     {
        //         _context.user.Remove(user);
        //     }
            
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        private bool userExists(int id)
        {
          return _context.user.Any(e => e.id == id);
        }
    }
}
