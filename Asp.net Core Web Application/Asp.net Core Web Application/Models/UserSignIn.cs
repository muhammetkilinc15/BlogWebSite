using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Web_Application.Models
{
    public class UserSignIn
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string password { get; set; }
    }
}
