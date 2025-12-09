using EventBooking.Data;
using EventBooking.Data.Services;
using EventBooking.Data.Static;
using EventBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBooking.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class VenuesController : Controller
    {
        private readonly IVenuesService _service;

        public VenuesController(IVenuesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allVenues = await _service.GetAllAsync();
            return View(allVenues);
        }


        //Get: Venues/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Picture,Name,Description")] Venue venue)
        {
            
            await _service.AddAsync(venue);
            return RedirectToAction(nameof(Index));
        }

        //Get: Venues/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var VenueDetails = await _service.GetByIdAsync(id);
            if (VenueDetails == null) return View("NotFound");
            return View(VenueDetails);
        }

        //Get: Venues/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var VenueDetails = await _service.GetByIdAsync(id);
            if (VenueDetails == null) return View("NotFound");
            return View(VenueDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Picture,Name,Description")] Venue venue)
        {
            
            if (id == venue.Id)
            {
                await _service.UpdateAsync(id, venue);
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        //Get: Venues/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var VenueDetails = await _service.GetByIdAsync(id);
            if (VenueDetails == null) return View("NotFound");
            return View(VenueDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var VenueDetails = await _service.GetByIdAsync(id);
            if (VenueDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

