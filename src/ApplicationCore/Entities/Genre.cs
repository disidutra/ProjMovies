using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Genre
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}