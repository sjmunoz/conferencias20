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
    public class ChatsController : Controller
    {
        private readonly MvcMovieContext _context;

        public ChatsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Chats
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Chat
                .Include(c => c.Conference)
                .Include(c => c.Room)
                .Include(b => b.User);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Chats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chat
                .Include(c => c.Conference)
                .Include(c => c.Room)
                .Include(p => p.Attendants)
                .ThenInclude(attendant => attendant.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var chatUser = await _context.ChatUser.FindAsync(currentUser.Id, chat.Id);
            var averageRating = 0;
            var totalRatings = 0;
            foreach (var attendant in chat.Attendants)
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
            ViewData["chatUser"] = chatUser;
            ViewData["currentUser"] = currentUser;

            return View(chat);
        }

        // GET: Chats/Create
        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Location");
            return View();
        }

        // POST: Chats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Topic,ModeratorId,Id,RoomID,ConferenceId,PersonId,EventDate,EndEventDate,Track")] Chat chat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", chat.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", chat.RoomID);
            return View(chat);
        }

        // GET: Chats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chat.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", chat.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", chat.RoomID);
            return View(chat);
        }

        // POST: Chats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Topic,ModeratorId,Id,RoomID,ConferenceId,PersonId,EventDate,EndEventDate,Track")] Chat chat)
        {
            if (id != chat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(chat.Id))
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
            ViewData["ConferenceId"] = new SelectList(_context.Conference, "Id", "Id", chat.ConferenceId);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", chat.RoomID);
            return View(chat);
        }

        // GET: Chats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chat
                .Include(c => c.Conference)
                .Include(c => c.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chat = await _context.Chat.FindAsync(id);
            _context.Chat.Remove(chat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // SUBSCRIBIR USUARIO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAttendant(int id)
        {
            var chat = await _context.Chat.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (chat == null || currentUser == null)
            {
                return NotFound();
            }

            var chatUser = new ChatUser();
            chatUser.Chat = chat;
            chatUser.User = currentUser;
            if (ModelState.IsValid)
            {
                _context.Add(chatUser);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAttendant(int id)
        {
            var chat = await _context.Chat.FindAsync(id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);
            var chatUser = await _context.ChatUser.FindAsync(currentUser.Id, chat.Id);

            _context.ChatUser.Remove(chatUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult giveRating(int id)
        {
            ViewData["ChatId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> giveRating(int id, [Bind("Rating")] ChatUser chatUser)
        {
            var chat = await _context.Chat.FirstOrDefaultAsync(m => m.Id == id);
            ApplicationUser currentUser = await _context.User.FirstOrDefaultAsync(i => i.UserName == @User.Identity.Name);

            if (chat == null || currentUser == null)
            {
                return NotFound();
            }

            var attendant = await _context.ChatUser.FindAsync(currentUser.Id, chat.Id);
            attendant.Rating = chatUser.Rating;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }

        private bool ChatExists(int id)
        {
            return _context.Chat.Any(e => e.Id == id);
        }
    }
}
