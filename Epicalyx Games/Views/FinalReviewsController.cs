using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EpicalyxGame.Models;

namespace EpicalyxGame.Views
{
    public class FinalReviewsController : Controller
    {
        private readonly EpicalyxGamesContextDb _context;

        public FinalReviewsController(EpicalyxGamesContextDb context)
        {
            _context = context;
        }

        // GET: FinalReviews
        public async Task<IActionResult> Index(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;
            var finalReviews = from s in _context.FinalReview.Include(f => f.Game).Include(f => f.User)
            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                finalReviews = finalReviews.Where(s => s.Game.GameName.Contains(searchString));
            }

            return View(await finalReviews.AsNoTracking().ToListAsync());

       
         


        }

        // GET: FinalReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalReview = await _context.FinalReview
                .Include(f => f.Game)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FinalReviewID == id);
            if (finalReview == null)
            {
                return NotFound();
            }

            return View(finalReview);
        }

        // GET: FinalReviews/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameName");
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "Username");
            return View();
        }

        // POST: FinalReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinalReviewID,Review,FinalRating,GameID,UserID")] FinalReview finalReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finalReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameName", "GameID", finalReview.GameID);
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "Username", "UserID", finalReview.UserID);
            return View(finalReview);
            
        }

        // GET: FinalReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalReview = await _context.FinalReview.FindAsync(id);
            if (finalReview == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameName", finalReview.GameID);
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "Username", finalReview.UserID);
            return View(finalReview);
        }

        // POST: FinalReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinalReviewID,Review,FinalRating,GameID,UserID")] FinalReview finalReview)
        {
            if (id != finalReview.FinalReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finalReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinalReviewExists(finalReview.FinalReviewID))
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
            ViewData["GameID"] = new SelectList(_context.Game, "GameName", "GameID" );
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "Username", "UserID");
            return View(finalReview);
        }

        // GET: FinalReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalReview = await _context.FinalReview
                .Include(f => f.Game)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FinalReviewID == id);
            if (finalReview == null)
            {
                return NotFound();
            }

            return View(finalReview);
        }

        // POST: FinalReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finalReview = await _context.FinalReview.FindAsync(id);
            _context.FinalReview.Remove(finalReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinalReviewExists(int id)
        {
            return _context.FinalReview.Any(e => e.FinalReviewID == id);
        }

        
    }
}

