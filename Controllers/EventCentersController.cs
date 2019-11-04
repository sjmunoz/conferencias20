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
    public class EventCentersController : Controller
    {
        private readonly MvcMovieContext _context;

        public EventCentersController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: EventCenters
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventCenter.ToListAsync());
        }

        // GET: EventCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCenter = await _context.EventCenter
                .Include(b => b.Rooms)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventCenter == null)
            {
                return NotFound();
            }

            return View(eventCenter);
        }


        // GET: AddRoom/Create
        public IActionResult AddRoom(int id)
        {
            ViewData["EventCenterId"] = id;
            return View();
        }

        // POST: AddRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoom(int id, [Bind("Capacity,Location")] Room room)
        {

            room.EventCenterId = id;
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: EventCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Type,ContactInfo,Address")] EventCenter eventCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventCenter);
        }

        // GET: EventCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCenter = await _context.EventCenter.FindAsync(id);
            if (eventCenter == null)
            {
                return NotFound();
            }
            return View(eventCenter);
        }

        // POST: EventCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Type,ContactInfo,Address")] EventCenter eventCenter)
        {
            if (id != eventCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventCenterExists(eventCenter.Id))
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
            return View(eventCenter);
        }

        // GET: EventCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCenter = await _context.EventCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventCenter == null)
            {
                return NotFound();
            }

            return View(eventCenter);
        }

        // POST: EventCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventCenter = await _context.EventCenter.FindAsync(id);
            _context.EventCenter.Remove(eventCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventCenterExists(int id)
        {
            return _context.EventCenter.Any(e => e.Id == id);
        }
    }
}
