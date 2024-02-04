using System.ComponentModel.DataAnnotations;

namespace HomeCompassApi.Services.Facilities
{
    public class ResourceDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
    }
}
