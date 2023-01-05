using System.ComponentModel.DataAnnotations;

namespace IdentityCoreMvc.Models
{
    public class RegisterVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Alani Zorunludur")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName Alani Zorunludur")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Alani Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Alani Zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }


        public string? TcNo { get; set; }




    }
}
