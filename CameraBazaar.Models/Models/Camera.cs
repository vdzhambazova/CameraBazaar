using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using CameraBazaar.Models.Enums;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegex;

namespace CameraBazaar.Models.Models
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required]
        [RegularExpression(ModelValidationRegex, ErrorMessage = ModelValidationMessage)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [MinIso]
        public int MinIso { get; set; }

        [MaxIso]
        public int MaxIso { get; set; }

        public bool IsFullFrame { get; set; }

        [MaxLength(15)]
        public string VideoResolution { get; set; }
        public LightMetering LightMetering { get; set; }

        [MaxLength(6000)]
        public string Descriotion { get; set; }

        [RegularExpression(ImageUrlValidationRegex, ErrorMessage = ImageUrlValidationMessage)]
        public string ImageUrl { get; set; }
    }
}