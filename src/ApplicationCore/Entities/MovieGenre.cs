using System;

namespace ApplicationCore.Entities
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public virtual int GenreId { get; set; }
        public virtual string GenreName { get; set; }        
    }
}