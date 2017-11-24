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
    public class SocialController : Controller
    {
        private readonly SocialCSContext _context;

        public SocialController(SocialCSContext context)
        {
            _context = context;
        }

        // GET: Social
        
        public async Task<IActionResult> Index()
        {
            var socialCSContext = _context.MvcArticles.Include(m => m.MvcUser);
            return View(await socialCSContext.ToListAsync());
        }

        // GET: Social/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcUser = await _context.MvcUser
                .SingleOrDefaultAsync(m => m.UserID == id);
            if (mvcUser == null)
            {
                return NotFound();
            }

            return View(mvcUser);
        }

        // GET: Social/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Social/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserID,Name,Email,Password,Age,Timestamp")] MvcUser mvcUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mvcUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mvcUser);
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

        // GET: Social/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcUser = await _context.MvcUser.SingleOrDefaultAsync(m => m.UserID == id);
            if (mvcUser == null)
            {
                return NotFound();
            }
            return View(mvcUser);
        }

        // POST: Social/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Name,Email,Password,Age,Timestamp")] MvcUser mvcUser)
        {
            if (id != mvcUser.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mvcUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MvcUserExists(mvcUser.UserID))
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
            return View(mvcUser);
        }

        // GET: Social/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcUser = await _context.MvcUser
                .SingleOrDefaultAsync(m => m.UserID == id);
            if (mvcUser == null)
            {
                return NotFound();
            }

            return View(mvcUser);
        }

        // POST: Social/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mvcUser = await _context.MvcUser.SingleOrDefaultAsync(m => m.UserID == id);
            _context.MvcUser.Remove(mvcUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MvcUserExists(int id)
        {
            return _context.MvcUser.Any(e => e.UserID == id);
        }
    }
}
