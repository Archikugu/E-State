using System.ComponentModel.DataAnnotations;

namespace EState.UI.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        public string Password { get; set; }
    }
}
