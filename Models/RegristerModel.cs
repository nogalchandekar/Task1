using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Task1.Models
{
    public class RegristerModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email ID is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords  not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Dept { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Fee is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Fee must be a non-negative value.")]
        public decimal Fee { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Qualification is required.")]
        public List<string> Qualification { get; set; }
    }
}
