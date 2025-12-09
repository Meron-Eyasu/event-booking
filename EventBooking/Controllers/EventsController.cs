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
    public class EventsController : Controller
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync(n => n.Venue);
            return View(allEvents);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allEvents = await _service.GetAllAsync(n => n.Venue);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allEvents.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allEvents.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allEvents);
        }

        //GET: Events/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var EventDetail = await _service.GetEventByIdAsync(id);
            return View(EventDetail);
        }

        //GET: Events/Create
        public async Task<IActionResult> Create()
        {
            var EventDropdownsData = await _service.GetNewEventDropdownsValues();

            ViewBag.Venues = new SelectList(EventDropdownsData.Venues, "Id", "Name");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEventVM evnt)
        {
            if (!ModelState.IsValid)
            {
                var EventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Venues = new SelectList(EventDropdownsData.Venues, "Id", "Name");
                
                return View(evnt);
            }

            await _service.AddNewEventAsync(evnt);
            return RedirectToAction(nameof(Index));
        }


        //GET: Events/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var EventDetails = await _service.GetEventByIdAsync(id);
            if (EventDetails == null) return View("NotFound");

            var response = new NewEventVM()
            {
                Id = EventDetails.Id,
                Name = EventDetails.Name,
                Description = EventDetails.Description,
                Price = EventDetails.Price,
                StartDate = EventDetails.StartDate,
                EndDate = EventDetails.EndDate,
                ImageURL = EventDetails.ImageURL,
                Category = EventDetails.Category,
                VenueId = EventDetails.VenueId,
               };

            var EventDropdownsData = await _service.GetNewEventDropdownsValues();
            ViewBag.Venues = new SelectList(EventDropdownsData.Venues, "Id", "Name");
            
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEventVM evnt)
        {
            if (id != evnt.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var EventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Venues = new SelectList(EventDropdownsData.Venues, "Id", "Name");
                
                return View(evnt);
            }

            await _service.UpdateEventAsync(evnt);
            return RedirectToAction(nameof(Index));
        }
    }
}
