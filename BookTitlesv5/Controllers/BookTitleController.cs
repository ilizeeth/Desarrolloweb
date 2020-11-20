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
    public class BookTitleController : Controller
    {
        private readonly BookContext _context;

        public BookTitleController(BookContext context)
        {
            _context = context;
        }

        // GET: BookTitle
        public async Task<IActionResult> Index(string searchString)
        {
            var bookTitles = from b in _context.BookTitles select b;
            if(!string.IsNullOrEmpty(searchString)){
                bookTitles = bookTitles.Where(b=>b.Title.Contains(searchString));
            }
            return View(await bookTitles.ToListAsync());
            
        }

        // GET: BookTitle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTitle = await _context.BookTitles
                .Include(b => b.BookFormat)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.ISBN_Number == id);
            if (bookTitle == null)
            {
                return NotFound();
            }

            return View(bookTitle);
        }

        // GET: BookTitle/Create
        public IActionResult Create(){
            
            ViewData["BookFormatID"] = new SelectList(_context.BookFormats, "BookFormatID", "FormatDescription");
            ViewData["PublisherID"] = new SelectList(_context.publishers, "PublisherID", "PublisherName");
            return View();
        }

        // POST: BookTitle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN_Number,Title,PublisherID,Published,BookFormatID,Pages,Price,Comments")] BookTitle bookTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookFormatID"] = new SelectList(_context.BookFormats, "BookFormatID", "FormatDescription", bookTitle.BookFormatID);
            ViewData["PublisherID"] = new SelectList(_context.publishers, "PublisherID", "PublisherName", bookTitle.PublisherID);
            return View(bookTitle);
        }

        // GET: BookTitle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTitle = await _context.BookTitles.FindAsync(id);
            if (bookTitle == null)
            {
                return NotFound();
            }
            
            //ViewData["BookFormatID"] = new SelectList(_context.BookFormats, "BookFormatID", "FormatDescription", bookTitle.BookFormatID);
            ViewData["PublisherID"] = new SelectList(_context.publishers, "PublisherID", "PublisherName", bookTitle.PublisherID);
            return View(bookTitle);
        }

        // POST: BookTitle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISBN_Number,Title,PublisherID,Published,BookFormatID,Pages,Price,Comments")] BookTitle bookTitle)
        {
            if (id != bookTitle.ISBN_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTitleExists(bookTitle.ISBN_Number))
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
            ViewData["BookFormatID"] = new SelectList(_context.BookFormats, "BookFormatID", "FormatDescription", bookTitle.BookFormatID);
            ViewData["PublisherID"] = new SelectList(_context.publishers, "PublisherID", "PublisherName", bookTitle.PublisherID);
            return View(bookTitle);
        }

        private void popularFormat(object selectedFormat=null){
            var FormatQuery = from f in _context.BookFormats
                    orderby f.FormatDescription
                    select f;
            ViewBag.BookFormatID = new SelectList(FormatQuery.AsNoTracking(),"BookFormarID","FormatDescription",selectedFormat);
        }

        // GET: BookTitle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTitle = await _context.BookTitles
                .Include(b => b.BookFormat)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.ISBN_Number == id);
            if (bookTitle == null)
            {
                return NotFound();
            }

            return View(bookTitle);
        }

        // POST: BookTitle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTitle = await _context.BookTitles.FindAsync(id);
            _context.BookTitles.Remove(bookTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTitleExists(int id)
        {
            return _context.BookTitles.Any(e => e.ISBN_Number == id);
        }
    }
}
