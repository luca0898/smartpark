namespace SmartPark.Domain.Entities
{
    public class Veicle
    {
        public Guid Id { get; set; }
        public required string Plate { get; set; }
        public DateTime ParkingAt { get; set; }
        public DateTime? FinishAt { get; set; }
        public TimeSpan? StayingTime { get { return ParkingAt - FinishAt ?? null; } }
    }
}
