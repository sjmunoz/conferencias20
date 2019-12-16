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
    public class TalksController : Controller
    {
        private readonly MvcMovieContext _context;

        public TalksController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Talks
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Talk
                .Include(t => t.Conference)
                .Include(t => t.Room)
                .Include(b => b.User);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Talks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talk = await _context.Talk
                .Include(t => t.Conference)
                .Include(t => t.Room)
                .Include(p => p.Attendants)
                .ThenInclude(attendant => attendant.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talk == null)
            {
                return NotFound();
            }

            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var talkUser = await _context.TalkUser.FindAsync(currentUser.Id, talk.Id);

            var averageRating = 0;
            foreach (var attendant in talk.Attendants)
            {
                try {
                averageRating += attendant.Rating.Value;
                }
                catch
                {
                    
                }
            }
            if(talk.Attendants.Count > 0) { 
                averageRating = averageRating / talk.Attendants.Count;
            }
            else
            {
                averageRating = 0;
            }

            ViewData["talkUser"] = talkUser;
            ViewData["currentUser"] = currentUser;
            ViewData["averageRating"] = averageRating;

            return View(talk);
        }

        // GET: Talks/Create
        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Location");
            ViewData["Talkers"] = new SelectList(_context.User, "UserName", "UserName");
            return View();
        }

        // POST: Talks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Resources,Talker,Id,RoomID,ConferenceId,EventDate,EndEventDate,Track")] Talk talk)
        {
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            talk.UserId = currentUser.Id;

            if (ModelState.IsValid)
            {
                _context.Add(talk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", talk.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", talk.RoomID);
            ViewData["Talkers"] = new SelectList(_context.User, "UserName", "UserName", talk.Talker);
            return View(talk);
        }

        // GET: Talks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talk = await _context.Talk.FindAsync(id);
            if (talk == null)
            {
                return NotFound();
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Name", talk.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Location", talk.RoomID);
            ViewData["Talkers"] = new SelectList(_context.User, "UserName", "UserName", talk.Talker);
            return View(talk);
        }

        // POST: Talks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Resources,Talker,Id,RoomID,ConferenceId,EventDate,EndEventDate,Track, UserId")] Talk talk)
        {
            if (id != talk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalkExists(talk.Id))
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
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", talk.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", talk.RoomID);
            ViewData["Talkers"] = new SelectList(_context.User, "UserName", "UserName", talk.Talker);
            return View(talk);
        }

        // GET: Talks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talk = await _context.Talk
                .Include(t => t.Conference)
                .Include(t => t.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talk == null)
            {
                return NotFound();
            }

            return View(talk);
        }

        // POST: Talks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talk = await _context.Talk.FindAsync(id);
            _context.Talk.Remove(talk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // SUBSCRIBIR USUARIO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAttendant(int id)
        {
            var talk = await _context.Talk.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (talk == null || currentUser == null)
            {
                return NotFound();
            }

            var talkUser = new TalkUser();
            talkUser.Talk = talk;
            talkUser.User = currentUser;
            if (ModelState.IsValid)
            {
                _context.Add(talkUser);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAttendant(int id)
        {
            var talk = await _context.Talk.FindAsync(id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var talkUser = await _context.TalkUser.FindAsync(currentUser.Id, talk.Id);

            _context.TalkUser.Remove(talkUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult giveRating(int id)
        {
            ViewData["TalkId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> giveRating(int id, [Bind("Rating")] TalkUser talkUser)
        {
            var talk = await _context.Talk.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (talk == null || currentUser == null)
            {
                return NotFound();
            }

            var attendant = await _context.TalkUser.FindAsync(currentUser.Id, talk.Id);
            attendant.Rating = talkUser.Rating;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }

        private bool TalkExists(int id)
        {
            return _context.Talk.Any(e => e.Id == id);
        }
    }
}
