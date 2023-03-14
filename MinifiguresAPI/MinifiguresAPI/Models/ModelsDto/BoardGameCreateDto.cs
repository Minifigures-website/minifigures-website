using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinifiguresAPI.Models.ModelsDto
{
    public class BoardGameCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string Authors { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        [DefaultValue("30 minutes")]
        public string AvgPlaytime { get; set; } = string.Empty;
        [Required]
        [Range(0, 100)]
        [DefaultValue(0)]
        public string PhysicalMinis { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
    }
}
