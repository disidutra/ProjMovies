using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Movie
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public virtual int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public ICollection<MovieRental> MovieRentals { get; set; }
    }
}