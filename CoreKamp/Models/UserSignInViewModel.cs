using System.ComponentModel.DataAnnotations;

namespace CoreKamp.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Girin")]
        public  string username  { get; set; }

        [Required(ErrorMessage = "Lütfen Parolanızı Adını Girin")]
        public  string password  { get; set; }
    }
}
