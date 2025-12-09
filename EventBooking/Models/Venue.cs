using EventBooking.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventBooking.Models
{
    public class Venue :IEntityBase
    {
        [Key]
        public int Id { get; set; }

   
        public string Picture { get; set; }

   
        public string Name { get; set; }

        public string Description { get; set; }

        //Relationships
        public List<Event> Events { get; set; }
    }
}
