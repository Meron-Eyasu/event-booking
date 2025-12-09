using EventBooking.Data.Base;
using EventBooking.Data.ViewModels;
using EventBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBooking.Data.Services
{
    public interface IEventsService : IEntityBaseRepository<Event>
    {
        Task<Event> GetEventByIdAsync(int id);
        Task<NewEventDropdownsVM> GetNewEventDropdownsValues();
        Task AddNewEventAsync(NewEventVM data);
        Task UpdateEventAsync(NewEventVM data);
    }
}


