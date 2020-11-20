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
    public class BookFormatController : Controller
    {
        private readonly BookContext _context;

        public BookFormatController(BookContext context)
        {
            _context = context;
        }

        // GET: BookFormat
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookFormats.ToListAsync());
        }

        // GET: BookFormat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookFormat = await _context.BookFormats
                .FirstOrDefaultAsync(m => m.BookFormatID == id);
            if (bookFormat == null)
            {
                return NotFound();
            }

            return View(bookFormat);
        }

        // GET: BookFormat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookFormat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookFormatID,FormatDescription")] BookFormat bookFormat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookFormat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookFormat);
        }

        // GET: BookFormat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookFormat = await _context.BookFormats.FindAsync(id);
            if (bookFormat == null)
            {
                return NotFound();
            }
            return View(bookFormat);
        }

        // POST: BookFormat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookFormatID,FormatDescription")] BookFormat bookFormat)
        {
            if (id != bookFormat.BookFormatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookFormat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookFormatExists(bookFormat.BookFormatID))
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
            return View(bookFormat);
        }

        // GET: BookFormat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookFormat = await _context.BookFormats
                .FirstOrDefaultAsync(m => m.BookFormatID == id);
            if (bookFormat == null)
            {
                return NotFound();
            }

            return View(bookFormat);
        }

        // POST: BookFormat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookFormat = await _context.BookFormats.FindAsync(id);
            _context.BookFormats.Remove(bookFormat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookFormatExists(int id)
        {
            return _context.BookFormats.Any(e => e.BookFormatID == id);
        }
    }
}
