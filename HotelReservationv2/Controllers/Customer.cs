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
    public class Customer : Controller
    {
        private readonly HotelContext _context;

        public Customer(HotelContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index(string SearchString)
        {   
            var customer = from c in _context.tblCustomer select c;
            if(!string.IsNullOrEmpty(SearchString)){
                customer = customer.Where(c=>c.txtCustomerSurnames.Contains(SearchString)|| c.txtCustomerTitle.Contains(SearchString)); }
            return View(await customer.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomers = await _context.tblCustomer
                .FirstOrDefaultAsync(m => m.IngCutomerID == id);
            if (tblCustomers == null)
            {
                return NotFound();
            }

            return View(tblCustomers);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngCutomerID,txtCustomerTitle,txtCustomerForenames,txtCustomerSurnames,CustomerDOB,txtCustomerAddressStreet,txtCustomerAddressTown,txtCustomerAddressCountry,txtCustomerAddressPostalCode,txtCustomerHomePhone,txtCustomerMobilePhone,hypCustomerEmail")] tblCustomers tblCustomers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCustomers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCustomers);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomers = await _context.tblCustomer.FindAsync(id);
            if (tblCustomers == null)
            {
                return NotFound();
            }
            return View(tblCustomers);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngCutomerID,txtCustomerTitle,txtCustomerForenames,txtCustomerSurnames,CustomerDOB,txtCustomerAddressStreet,txtCustomerAddressTown,txtCustomerAddressCountry,txtCustomerAddressPostalCode,txtCustomerHomePhone,txtCustomerMobilePhone,hypCustomerEmail")] tblCustomers tblCustomers)
        {
            if (id != tblCustomers.IngCutomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCustomers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCustomersExists(tblCustomers.IngCutomerID))
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
            return View(tblCustomers);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomers = await _context.tblCustomer
                .FirstOrDefaultAsync(m => m.IngCutomerID == id);
            if (tblCustomers == null)
            {
                return NotFound();
            }

            return View(tblCustomers);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCustomers = await _context.tblCustomer.FindAsync(id);
            _context.tblCustomer.Remove(tblCustomers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCustomersExists(int id)
        {
            return _context.tblCustomer.Any(e => e.IngCutomerID == id);
        }
    }
}
