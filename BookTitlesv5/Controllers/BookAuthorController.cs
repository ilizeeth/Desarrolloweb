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
    public class BookAuthorController : Controller
    {
        private readonly BookContext _context;

        public BookAuthorController(BookContext context)
        {
            _context = context;
        }

        // GET: BookAuthor
        public async Task<IActionResult> Index()
        {
            var bookContext = _context.Book_Authors.Include(b => b.Author);
            return View(await bookContext.ToListAsync());
        }

        // GET: BookAuthor/Details/5
        public async Task<IActionResult> Details(int? id, int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book_Author = await _context.Book_Authors
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ISBN_Number == id && m.AuthorID==id2) ;
            if (book_Author == null)
            {
                return NotFound();
            }

            return View(book_Author);
        }

        // GET: BookAuthor/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "FullName");
            return View();
        }

        // POST: BookAuthor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN_Number,AuthorID")] Book_Author book_Author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book_Author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "FullName", book_Author.AuthorID);
            return View(book_Author);
        }

        // GET: BookAuthor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book_Author = await _context.Book_Authors.FindAsync(id);
            if (book_Author == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "FullName", book_Author.AuthorID);
            return View(book_Author);
        }

        // POST: BookAuthor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISBN_Number,AuthorID")] Book_Author book_Author)
        {
            if (id != book_Author.ISBN_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book_Author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Book_AuthorExists(book_Author.ISBN_Number))
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
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "FullName", book_Author.AuthorID);
            return View(book_Author);
        }

        // GET: BookAuthor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book_Author = await _context.Book_Authors
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ISBN_Number == id);
            if (book_Author == null)
            {
                return NotFound();
            }

            return View(book_Author);
        }

        // POST: BookAuthor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book_Author = await _context.Book_Authors.FindAsync(id);
            _context.Book_Authors.Remove(book_Author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Book_AuthorExists(int id)
        {
            return _context.Book_Authors.Any(e => e.ISBN_Number == id);
        }
    }
}
