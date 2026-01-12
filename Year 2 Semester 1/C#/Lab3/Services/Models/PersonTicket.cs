namespace Services.Models
{
    public class PersonTicket
    {
        public int? Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? QrCode { get; set; }
        public bool HasTicket
        {
            get => QrCode != null;
        }
    }
}
