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
            var mvcMovieContext = _context.Conference.Include(b => b.User).Include(c => c.EventCenter);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Conferences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var conference = await _context.Conference
                .Include(b => b.Parties)
                .Include(b => b.Talks)
                .Include(b => b.Chats)
                .Include(b => b.Dinners)
                .Include(b => b.User)
                .Include(c => c.EventCenter)
                .Include(c => c.Repetitions)
                .Include(c => c.Attendants)
                .FirstOrDefaultAsync(m => m.Id == id);
            var conferenceUser = await _context.ConferenceUser.FindAsync(currentUser.Id, conference.Id);
            if (conference == null)
            {
                return NotFound();
            }

            ViewData["conferenceUser"] = conferenceUser;
            ViewData["available"] = conference.Attendants.Count - conference.Spots;
            return View(conference);
        }

        // GET: AddRepetition/Create
        public IActionResult AddRepetition(int id)
        {
            ViewData["ConferenceId"] = id;
            return View();
        }

        // POST: AddRepetition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRepetition(int id, [Bind("Day, Month, Year")] Repetition repetition)
        {

            repetition.ConferenceId = id;
            if (ModelState.IsValid)
            {
                _context.Add(repetition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repetition);
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
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Description,Price,EventCenterId, Spots")] Conference conference)
        {
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            conference.UserId = currentUser.Id;

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Description,Price,EventCenterId, UserId, Spots")] Conference conference)
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

        // SUBSCRIBIR USUARIO A CONFERENCIA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAttendant(int id)
        {
            var conference = await _context.Conference.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (conference == null || currentUser == null)
            {
                return NotFound();
            }

            var conferenceUser = new ConferenceUser();
            conferenceUser.Conference = conference;
            conferenceUser.User = currentUser;
            if (ModelState.IsValid)
            {
                _context.Add(conferenceUser);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAttendant(int id)
        {
            var conference = await _context.Conference.FindAsync(id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var conferenceUser = await _context.ConferenceUser.FindAsync(currentUser.Id, conference.Id);

            _context.ConferenceUser.Remove(conferenceUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        private bool ConferenceExists(int id)
        {
            return _context.Conference.Any(e => e.Id == id);
        }
    }
}
