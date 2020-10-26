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
    public class Booking : Controller
    {
        private readonly HotelContext _context;

        public Booking(HotelContext context)
        {
            _context = context;
        }

        // GET: Booking
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblBooking.ToListAsync());
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBookings = await _context.tblBooking
                .FirstOrDefaultAsync(m => m.ingBookingID == id);
            if (tblBookings == null)
            {
                return NotFound();
            }

            return View(tblBookings);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ingBookingID,ingCustomerID,dteDateBookingMade,tmeTimeBookingMade,dteBookedStartDate,dteBookedEndDate,dteTotalPaymentDueDate,dteTotalPaymentDueAmount,memBookingComments,dteTotalPaymentMadeOn")] tblBookings tblBookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBookings);
        }

        // GET: Booking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBookings = await _context.tblBooking.FindAsync(id);
            if (tblBookings == null)
            {
                return NotFound();
            }
            return View(tblBookings);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ingBookingID,ingCustomerID,dteDateBookingMade,tmeTimeBookingMade,dteBookedStartDate,dteBookedEndDate,dteTotalPaymentDueDate,dteTotalPaymentDueAmount,memBookingComments,dteTotalPaymentMadeOn")] tblBookings tblBookings)
        {
            if (id != tblBookings.ingBookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblBookingsExists(tblBookings.ingBookingID))
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
            return View(tblBookings);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBookings = await _context.tblBooking
                .FirstOrDefaultAsync(m => m.ingBookingID == id);
            if (tblBookings == null)
            {
                return NotFound();
            }

            return View(tblBookings);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBookings = await _context.tblBooking.FindAsync(id);
            _context.tblBooking.Remove(tblBookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblBookingsExists(int id)
        {
            return _context.tblBooking.Any(e => e.ingBookingID == id);
        }
    }
}
