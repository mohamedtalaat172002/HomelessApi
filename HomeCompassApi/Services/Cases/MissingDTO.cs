using System.ComponentModel.DataAnnotations;

namespace HomeCompassApi.Services.Cases
{
    public class MissingDTO
    {
        [Required]
        public string FullName { get; set; }
        public string Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ReporterId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

        public DateTime DateOfDisappearance { get; set; }

        public string LastKnownLocation { get; set; }

        public string PhysicalDescription { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string ContactNumber { get; set; }
        
    }
}
