namespace Tourism_App.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public string Name { get; set; } = string.Empty;       // Added Name
        public string Phone { get; set; } = string.Empty;      // Added Phone

        public int NumberOfPeople { get; set; }
        public decimal ChargePerPerson { get; set; }
        public decimal TotalCost { get; set; }                 // Can be calculated as NumberOfPeople * ChargePerPerson in code

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Destination? Destination { get; set; }
    }
}
