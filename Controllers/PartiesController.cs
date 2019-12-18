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
    public class PartiesController : Controller
    {
        private readonly MvcMovieContext _context;

        public PartiesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Party
                .Include(p => p.Conference)
                .Include(p => p.Room)
                .Include(b => b.User);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party
                .Include(p => p.Conference)
                .Include(p => p.Room)
                .Include(p => p.Attendants)
                .ThenInclude(attendant => attendant.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (party == null)
            {
                return NotFound();
            }

            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var partyUser = await _context.PartyUser.FindAsync(currentUser.Id, party.Id);
            var averageRating = 0;
            var totalRatings = 0;
            foreach (var attendant in party.Attendants)
            {
                if (attendant.Rating != null)
                {
                    averageRating += attendant.Rating.Value;
                    totalRatings += 1;
                }
            }
            if (totalRatings > 0)
            {
                averageRating = averageRating / totalRatings;
            }

            ViewData["averageRating"] = averageRating;
            ViewData["partyUser"] = partyUser;
            ViewData["currentUser"] = currentUser;

            return View(party);
        }

        // GET: Parties/Create
        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Location");
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomID,ConferenceId,PersonId,EventDate,EndEventDate,Track")] Party party)
        {
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            party.UserId = currentUser.Id;
            if (ModelState.IsValid)
            {
                _context.Add(party);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", party.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", party.RoomID);
            return View(party);
        }

        // GET: Parties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", party.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", party.RoomID);
            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomID,ConferenceId,PersonId,EventDate,EndEventDate,Track,UserId")] Party party)
        {
            if (id != party.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(party);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyExists(party.Id))
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
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", party.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", party.RoomID);
            return View(party);
        }

        // GET: Parties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party
                .Include(p => p.Conference)
                .Include(p => p.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var party = await _context.Party.FindAsync(id);
            _context.Party.Remove(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // SUBSCRIBIR USUARIO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAttendant(int id)
        {
            var party = await _context.Party.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (party == null || currentUser == null)
            {
                return NotFound();
            }

            var partyUser = new PartyUser();
            partyUser.Party = party;
            partyUser.User = currentUser;
            if (ModelState.IsValid)
            {
                _context.Add(partyUser);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAttendant(int id)
        {
            var party = await _context.Party.FindAsync(id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var partyUser = await _context.PartyUser.FindAsync(currentUser.Id, party.Id);

            _context.PartyUser.Remove(partyUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult giveRating(int id)
        {
            ViewData["PartyId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> giveRating(int id, [Bind("Rating")] PartyUser partyUser)
        {
            var party = await _context.Party.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (party == null || currentUser == null)
            {
                return NotFound();
            }

            var attendant = await _context.PartyUser.FindAsync(currentUser.Id, party.Id);
            attendant.Rating = partyUser.Rating;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }

        private bool PartyExists(int id)
        {
            return _context.Party.Any(e => e.Id == id);
        }
    }
}
