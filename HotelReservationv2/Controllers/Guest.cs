using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservationv2.Data;
using HotelReservationv2.Models;

namespace HotelReservationv2.Controllers
{
    public class Guest : Controller
    {
        private readonly HotelContext _context;

        public Guest(HotelContext context)
        {
            _context = context;
        }

        // GET: Guest
        public async Task<IActionResult> Index(string SearchString)
        {   
            var guest = from g in _context.tblGuest select g;
            if(!string.IsNullOrEmpty(SearchString)){
                guest = guest.Where(g=>g.txtGuestSurnames.Contains(SearchString)|| g.txtGuestTitle.Contains(SearchString)); }
            return View(await guest.ToListAsync());
        }


        // GET: Guest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuests = await _context.tblGuest
                .FirstOrDefaultAsync(m => m.ingGuestID == id);
            if (tblGuests == null)
            {
                return NotFound();
            }

            return View(tblGuests);
        }

        // GET: Guest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ingGuestID,txtGuestTitle,txtGuestForenames,txtGuestSurnames,dteGuestDOB,txtGuestAddressStreet,txtGuestAddressTown,txtGuestAddressCountry,txtGuestAddressPostalCode,txtGuestContactPhone")] tblGuests tblGuests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGuests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblGuests);
        }

        // GET: Guest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuests = await _context.tblGuest.FindAsync(id);
            if (tblGuests == null)
            {
                return NotFound();
            }
            return View(tblGuests);
        }

        // POST: Guest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ingGuestID,txtGuestTitle,txtGuestForenames,txtGuestSurnames,dteGuestDOB,txtGuestAddressStreet,txtGuestAddressTown,txtGuestAddressCountry,txtGuestAddressPostalCode,txtGuestContactPhone")] tblGuests tblGuests)
        {
            if (id != tblGuests.ingGuestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGuests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblGuestsExists(tblGuests.ingGuestID))
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
            return View(tblGuests);
        }

        // GET: Guest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuests = await _context.tblGuest
                .FirstOrDefaultAsync(m => m.ingGuestID == id);
            if (tblGuests == null)
            {
                return NotFound();
            }

            return View(tblGuests);
        }

        // POST: Guest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGuests = await _context.tblGuest.FindAsync(id);
            _context.tblGuest.Remove(tblGuests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblGuestsExists(int id)
        {
            return _context.tblGuest.Any(e => e.ingGuestID == id);
        }
    }
}
