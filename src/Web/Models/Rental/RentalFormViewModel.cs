using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class RentalFormViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }        
        public DateTime DateRental { get; set; }
        public IList<RentalFormMovieViewModel> MovieRentals { get; set; }
    }
}