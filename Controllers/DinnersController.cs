using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class DinnersController : Controller
    {
        private readonly MvcMovieContext _context;

        public DinnersController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Dinners
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Dinner
                .Include(d => d.Conference)
                .Include(d => d.Room)
                .Include(b => b.User);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Dinners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinner = await _context.Dinner
                .Include(d => d.Conference)
                .Include(d => d.Room)
                .Include(p => p.Attendants)
                .ThenInclude(attendant => attendant.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dinner == null)
            {
                return NotFound();
            }

            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var dinnerUser = await _context.DinnerUser.FindAsync(currentUser.Id, dinner.Id);
            ViewData["dinnerUser"] = dinnerUser;
            ViewData["currentUser"] = currentUser;

            return View(dinner);
        }

        // GET: Dinners/Create
        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Location");
            return View();
        }

        // POST: Dinners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Location,Menu,Id,RoomID,ConferenceId,PersonId,EventDate,EndEventDate,Track")] Dinner dinner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dinner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", dinner.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", dinner.RoomID);
            return View(dinner);
        }

        // GET: Dinners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinner = await _context.Dinner.FindAsync(id);
            if (dinner == null)
            {
                return NotFound();
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", dinner.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", dinner.RoomID);
            return View(dinner);
        }

        // POST: Dinners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Location,Menu,Id,RoomID,ConferenceId,PersonId,EventDate,EndEventDate,Track")] Dinner dinner)
        {
            if (id != dinner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dinner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DinnerExists(dinner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", dinner.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", dinner.RoomID);
            return View(dinner);
        }

        // GET: Dinners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinner = await _context.Dinner
                .Include(d => d.Conference)
                .Include(d => d.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dinner == null)
            {
                return NotFound();
            }

            return View(dinner);
        }

        // POST: Dinners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dinner = await _context.Dinner.FindAsync(id);
            _context.Dinner.Remove(dinner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // SUBSCRIBIR USUARIO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAttendant(int id)
        {
            var dinner = await _context.Dinner.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (dinner == null || currentUser == null)
            {
                return NotFound();
            }

            var dinnerUser = new DinnerUser();
            dinnerUser.Dinner = dinner;
            dinnerUser.User = currentUser;
            if (ModelState.IsValid)
            {
                _context.Add(dinnerUser);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAttendant(int id)
        {
            var dinner = await _context.Dinner.FindAsync(id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var dinnerUser = await _context.DinnerUser.FindAsync(currentUser.Id, dinner.Id);

            _context.DinnerUser.Remove(dinnerUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        private bool DinnerExists(int id)
        {
            return _context.Dinner.Any(e => e.Id == id);
        }
    }
}
