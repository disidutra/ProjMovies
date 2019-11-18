using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Rental
    {
     public int Id { get; set; }
     public User User { get; set; }
     public DateTime DateRental { get; set; }   
     public ICollection<MovieRental> MovieRentals { get; set; }
    }
}