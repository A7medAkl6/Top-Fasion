﻿using System.ComponentModel.DataAnnotations;

namespace Top_Fashion.TopFashion.Domain.Dtos
{
    public class RegisterDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min Length is 3 character")]
        public string DisplayName { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Password It expects at least 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-10 characters")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^(01[0-2]|015)(\d{8})$", ErrorMessage = "Invaild Phone")]
        public string PhoneNumber { get; set; }

    }
}
