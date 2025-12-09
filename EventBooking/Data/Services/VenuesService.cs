using EventBooking.Data.Base;
using EventBooking.Data.ViewModels;
using EventBooking.Models;
using EventBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Data.Services
{
    public class VenuesService : EntityBaseRepository<Venue>, IVenuesService
    {
        public VenuesService(AppDbContext context) : base(context)
        {
        }
    }
}
