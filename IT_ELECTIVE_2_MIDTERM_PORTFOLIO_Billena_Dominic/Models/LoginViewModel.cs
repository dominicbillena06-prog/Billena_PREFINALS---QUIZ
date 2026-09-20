using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_PORTFOLIO_Billena_Dominic.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }
}