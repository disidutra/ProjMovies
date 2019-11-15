using System;

namespace ApplicationCore.Entities
{
    public class Rental
    {
     public int Id { get; set; }
     public User User { get; set; }
     public DateTime DateRental { get; set; }   
    }
}