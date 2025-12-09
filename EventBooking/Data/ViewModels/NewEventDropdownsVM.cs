using EventBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace EventBooking.Data.ViewModels
{
    public class NewEventDropdownsVM
    {
        public NewEventDropdownsVM()
        {
           Venues = new List<Venue>();
        }
         public List<Venue> Venues { get; set; }
    }
}
