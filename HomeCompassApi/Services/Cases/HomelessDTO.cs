using System.ComponentModel.DataAnnotations;

namespace HomeCompassApi.Services.Cases
{
    public class HomelessDTO
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
        public string CurrentLocation { get; set; }
        public string HealthCondition { get; set; }
    }
}
