namespace ApplicationCore.Entities
{
    public class MovieRental
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Rental Rental { get; set; }
    }
}