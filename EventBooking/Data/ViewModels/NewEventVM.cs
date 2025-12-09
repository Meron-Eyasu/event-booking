using System.ComponentModel.DataAnnotations;

namespace EventBooking.Models
{
    public class NewEventVM
    {
        public int Id { get; set; }

        [Display(Name = "Event name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Event description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Event poster URL")]
        [Required(ErrorMessage = "Event poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Event start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Event end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Event category is required")]
        public string Category { get; set; }

        //Relationships
        [Display(Name = "Select a Venue")]
        [Required(ErrorMessage = "Event Venue is required")]
        public int VenueId { get; set; }
    }
}
