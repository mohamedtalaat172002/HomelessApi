using System.ComponentModel.DataAnnotations;

namespace HomeCompassApi.Services.Facilities
{
    public class FacilityDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string ContributorId { get; set; }
        public string ContactInformaton { get; set; }
        public string Description { get; set; }
        public string Target { get; set; }
        public List<string> Days { get; set; }
        public int Hours { get; set; }
    }
}
