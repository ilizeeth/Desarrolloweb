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
    public class Rooms : Controller
    {
        private readonly HotelContext _context;

        public Rooms(HotelContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblRoom.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRooms = await _context.tblRoom
                .FirstOrDefaultAsync(m => m.ingRoomID == id);
            if (tblRooms == null)
            {
                return NotFound();
            }

            return View(tblRooms);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ingRoomID,ingRoomTypeID,ingRoomBandID,ingRoomPriceID,strFloor,memAdditionNotes")] tblRooms tblRooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblRooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblRooms);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRooms = await _context.tblRoom.FindAsync(id);
            if (tblRooms == null)
            {
                return NotFound();
            }
            return View(tblRooms);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ingRoomID,ingRoomTypeID,ingRoomBandID,ingRoomPriceID,strFloor,memAdditionNotes")] tblRooms tblRooms)
        {
            if (id != tblRooms.ingRoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblRoomsExists(tblRooms.ingRoomID))
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
            return View(tblRooms);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRooms = await _context.tblRoom
                .FirstOrDefaultAsync(m => m.ingRoomID == id);
            if (tblRooms == null)
            {
                return NotFound();
            }

            return View(tblRooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRooms = await _context.tblRoom.FindAsync(id);
            _context.tblRoom.Remove(tblRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblRoomsExists(int id)
        {
            return _context.tblRoom.Any(e => e.ingRoomID == id);
        }
    }
}
