using Lab26Tom.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab26Tom.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lab26TomContext _context;

        public HomeController(Lab26TomContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Calling to the LFG table in the database and getting the content for ID 1
            var result = _context.LFG.Where(c => c.ID == 1);

            return View(result.ToList());
        }
    }
}
