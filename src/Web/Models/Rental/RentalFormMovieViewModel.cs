using System;

namespace Web.Models
{
    public class RentalFormMovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public int GenreId { get; set; }
        public bool Rental { get; set; }        
    }
}