using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialCS.Models;

namespace SocialCS.Controllers
{
    public class PostController : Controller
    {
        private readonly SocialCSContext _context;

        public PostController(SocialCSContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var socialCSContext = _context.MvcArticles.Include(m => m.MvcUser);
            return View(await socialCSContext.ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcArticles = await _context.MvcArticles
                .Include(m => m.MvcUser)
                .SingleOrDefaultAsync(m => m.ArticlesID == id);
            if (mvcArticles == null)
            {
                return NotFound();
            }

            return View(mvcArticles);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.MvcUser, "UserID", "UserID");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticlesID,Title,Author,Timestamp,Text,UserID")] MvcArticles mvcArticles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mvcArticles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.MvcUser, "UserID", "UserID", mvcArticles.UserID);
            return View(mvcArticles);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcArticles = await _context.MvcArticles.SingleOrDefaultAsync(m => m.ArticlesID == id);
            if (mvcArticles == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.MvcUser, "UserID", "UserID", mvcArticles.UserID);
            return View(mvcArticles);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticlesID,Title,Author,Timestamp,Text,UserID")] MvcArticles mvcArticles)
        {
            if (id != mvcArticles.ArticlesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mvcArticles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MvcArticlesExists(mvcArticles.ArticlesID))
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
            ViewData["UserID"] = new SelectList(_context.MvcUser, "UserID", "UserID", mvcArticles.UserID);
            return View(mvcArticles);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcArticles = await _context.MvcArticles
                .Include(m => m.MvcUser)
                .SingleOrDefaultAsync(m => m.ArticlesID == id);
            if (mvcArticles == null)
            {
                return NotFound();
            }

            return View(mvcArticles);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mvcArticles = await _context.MvcArticles.SingleOrDefaultAsync(m => m.ArticlesID == id);
            _context.MvcArticles.Remove(mvcArticles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MvcArticlesExists(int id)
        {
            return _context.MvcArticles.Any(e => e.ArticlesID == id);
        }
    }
}
