using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcLandlord.Data;
using Restify.Models;

namespace Restify.Controllers
{
    public class LandlordsController : Controller
    {
        private readonly MvcLandlordContext _context;

        public LandlordsController(MvcLandlordContext context)
        {
            _context = context;
        }

        // GET: Landlords
        public async Task<IActionResult> Index()
        {
            return View(await _context.Landlord.ToListAsync());
        }

        // GET: Landlords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landlord = await _context.Landlord
                .FirstOrDefaultAsync(m => m.landlord_id == id);
            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        // GET: Landlords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Landlords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("landlord_id,landlord_firstname,landlord_lastname,landlord_email,landlord_contact,landlord_password")] Landlord landlord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landlord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(landlord);
        }

        // GET: Landlords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landlord = await _context.Landlord.FindAsync(id);
            if (landlord == null)
            {
                return NotFound();
            }
            return View(landlord);
        }

        // POST: Landlords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("landlord_id,landlord_firstname,landlord_lastname,landlord_email,landlord_contact,landlord_password")] Landlord landlord)
        {
            if (id != landlord.landlord_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landlord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandlordExists(landlord.landlord_id))
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
            return View(landlord);
        }

        // GET: Landlords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landlord = await _context.Landlord
                .FirstOrDefaultAsync(m => m.landlord_id == id);
            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        // POST: Landlords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landlord = await _context.Landlord.FindAsync(id);
            if (landlord != null)
            {
                _context.Landlord.Remove(landlord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandlordExists(int id)
        {
            return _context.Landlord.Any(e => e.landlord_id == id);
        }
    }
}
