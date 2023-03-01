namespace MinifiguresAPI.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Authors { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AvgPlaytime { get; set; } = string.Empty;
        public string PhysicalMinis { get; set; } = string.Empty;
        public DateTime DateAdded { get; set;}
        public DateTime? DateModified { get; set; }
    }
}
