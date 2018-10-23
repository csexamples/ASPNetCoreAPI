using System;
using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models
{
    public class PointsOfInterestForCreation
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "The description length cannot exceed 200 characters.")]
        public string Description { get; set; }
    }
}
