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
    public class RepetitionsController : Controller
    {
        private readonly MvcMovieContext _context;

        public RepetitionsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Repetitions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repetition.ToListAsync());
        }

        // GET: Repetitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repetition = await _context.Repetition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repetition == null)
            {
                return NotFound();
            }

            return View(repetition);
        }

        // GET: Repetitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repetitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Day,Month,Year,ConferenceId")] Repetition repetition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repetition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repetition);
        }

        // GET: Repetitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repetition = await _context.Repetition.FindAsync(id);
            if (repetition == null)
            {
                return NotFound();
            }
            return View(repetition);
        }

        // POST: Repetitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Day,Month,Year,ConferenceId")] Repetition repetition)
        {
            if (id != repetition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repetition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepetitionExists(repetition.Id))
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
            return View(repetition);
        }

        // GET: Repetitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repetition = await _context.Repetition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repetition == null)
            {
                return NotFound();
            }

            return View(repetition);
        }

        // POST: Repetitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repetition = await _context.Repetition.FindAsync(id);
            _context.Repetition.Remove(repetition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepetitionExists(int id)
        {
            return _context.Repetition.Any(e => e.Id == id);
        }
    }
}
