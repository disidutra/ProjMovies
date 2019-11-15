namespace ApplicationCore.Entities
{
    public class RentalMovie
    {
        public int Id { get; set; }
        public Rental Retal { get; set; }
        public Movie Movie { get; set; }
    }
}