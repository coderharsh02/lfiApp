using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {

        // [Phone] attribute is used to validate the phone number.
        // [MaxLength(10)] attribute is used to validate the maximum length of the phone number.
        // [RegularExpression(@"^[0-9]*$")] attribute is used to validate the phone number.
        
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}