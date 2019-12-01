using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {

        private readonly MvcMovieContext _context;

        public HomeController(MvcMovieContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var conference = await _context.Conference
                .Include(c => c.EventCenter)
                .FirstOrDefaultAsync(c => c.Id == 1);
            if (conference == null)
            {
                return NotFound();
            }

            return View(conference);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
