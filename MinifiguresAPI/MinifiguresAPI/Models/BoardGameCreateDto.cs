namespace MinifiguresAPI.Models
{
    public class BoardGameCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Authors { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AvgPlaytime { get; set; } = string.Empty;
        public string PhysicalMinis { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
    }
}
