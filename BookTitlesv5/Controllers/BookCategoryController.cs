using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookTitles.Data;
using BookTitles.Models;

namespace BookTitles.Controllers
{
    public class BookCategoryController : Controller
    {
        private readonly BookContext _context;

        public BookCategoryController(BookContext context)
        {
            _context = context;
        }

        // GET: BookCategory
        public async Task<IActionResult> Index()
        {
            var bookContext = _context.BookCategories.Include(b => b.Category);
            return View(await bookContext.ToListAsync());
        }

        // GET: BookCategory/Details/5
        public async Task<IActionResult> Details(int? id,int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.ISBN_Number == id && m.CategoryID==id2);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // GET: BookCategory/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryDescription");
            return View();
        }

        // POST: BookCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN_Number,CategoryID")] BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", bookCategory.CategoryID);
            return View(bookCategory);
        }

        // GET: BookCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", bookCategory.CategoryID);
            return View(bookCategory);
        }

        // POST: BookCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISBN_Number,CategoryID")] BookCategory bookCategory)
        {
            if (id != bookCategory.ISBN_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoryExists(bookCategory.ISBN_Number))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", bookCategory.CategoryID);
            return View(bookCategory);
        }

        // GET: BookCategory/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null || id2==null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .Include(b => b.Category)
                .Include(b => b.BookTitle)
                .FirstOrDefaultAsync(m => m.ISBN_Number == id && m.CategoryID==id2);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // POST: BookCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCategory = await _context.BookCategories.FindAsync(id);
            _context.BookCategories.Remove(bookCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoryExists(int id)
        {
            return _context.BookCategories.Any(e => e.ISBN_Number == id);
        }
    }
}
