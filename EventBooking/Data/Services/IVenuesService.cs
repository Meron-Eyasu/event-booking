using EventBooking.Data.Base;
using EventBooking.Data.ViewModels;
using EventBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBooking.Data.Services
{
    public interface IVenuesService : IEntityBaseRepository<Venue>
    {
    }
}
