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
    public class ConferencesController : Controller
    {
        private readonly MvcMovieContext _context;

        public ConferencesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Conferences
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Conference.Include(c => c.EventCenter);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Conferences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conference = await _context.Conference
                .Include(c => c.EventCenter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conference == null)
            {
                return NotFound();
            }

            return View(conference);
        }

        // GET: Conferences/Create
        public IActionResult Create()
        {
            ViewData["EventCenterId"] = new SelectList(_context.EventCenter, "Id", "Id");
            ViewData["EventCenterName"] = new SelectList(_context.EventCenter, "Id", "Name");
            return View();
        }

        // POST: Conferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Description,Price,EventCenterId")] Conference conference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventCenterId"] = new SelectList(_context.EventCenter, "Id", "Id", conference.EventCenterId);
            return View(conference);
        }

        // GET: Conferences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conference = await _context.Conference.FindAsync(id);
            if (conference == null)
            {
                return NotFound();
            }
            ViewData["EventCenterId"] = new SelectList(_context.EventCenter, "Id", "Id", conference.EventCenterId);
            return View(conference);
        }

        // POST: Conferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Description,Price,EventCenterId")] Conference conference)
        {
            if (id != conference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferenceExists(conference.Id))
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
            ViewData["EventCenterId"] = new SelectList(_context.EventCenter, "Id", "Id", conference.EventCenterId);
            return View(conference);
        }

        // GET: Conferences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conference = await _context.Conference
                .Include(c => c.EventCenter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conference == null)
            {
                return NotFound();
            }

            return View(conference);
        }

        // POST: Conferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conference = await _context.Conference.FindAsync(id);
            _context.Conference.Remove(conference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConferenceExists(int id)
        {
            return _context.Conference.Any(e => e.Id == id);
        }
    }
}
