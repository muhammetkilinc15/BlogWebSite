using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Web_Application.Areas.Admin.Models
{
	public class RoleViewModel
	{
        [Required(ErrorMessage ="Lütfen bir rol adı giriniz")]
        public string name { get; set; }
    }
}
