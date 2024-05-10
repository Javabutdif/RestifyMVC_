﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApartment.Data;
using Restify.Models;

namespace Restify.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly MvcApartmentContext _context;

        public ApartmentsController(MvcApartmentContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var apartments = await _context.Apartment.ToListAsync();

            // Convert byte arrays to base64 strings for image display
            foreach (var apartment in apartments)
            {
                apartment.apartment_base = Convert.ToBase64String(apartment.apartment_image);
            }

            return View(apartments);
        }


        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment
                .FirstOrDefaultAsync(m => m.apartment_id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string? name, string? details, string? location, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null && image.Length > 0)
                    {
                        // Read the image file into a byte array
                        using (var memoryStream = new MemoryStream())
                        {
                            await image.CopyToAsync(memoryStream);
                            // Set the apartment image property to the byte array
                            byte[] imageBytes = memoryStream.ToArray();

                            // Create a new apartment object and set its properties
                            Apartment apartment = new Apartment
                            {
                                apartment_name = name,
                                apartment_details = details,
                                apartment_location = location,
                                apartment_image = imageBytes
                            };

                            // Add the apartment to the context
                            _context.Add(apartment);
                            // Save changes to the database
                            await _context.SaveChangesAsync();
                            // Redirect to the index action method
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        // Handle the case where no image is provided
                        ModelState.AddModelError("image", "Please select an image file.");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    ModelState.AddModelError("", "An error occurred while saving the apartment information.");
                    // Return the view with the model state
                    return View();
                }
            }
            // If the model state is not valid, return the view with the apartment object
            return View();
        }


        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("apartment_id,apartment_name,apartment_details,apartment_location,apartment_image")] Apartment apartment)
        {
            if (id != apartment.apartment_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.apartment_id))
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
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment
                .FirstOrDefaultAsync(m => m.apartment_id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var apartment = await _context.Apartment.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartment.Remove(apartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int? id)
        {
            return _context.Apartment.Any(e => e.apartment_id == id);
        }
    }
}
