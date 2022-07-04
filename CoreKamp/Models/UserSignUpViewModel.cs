﻿using System.ComponentModel.DataAnnotations;

namespace CoreKamp.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz")]
        public string NameSurname { get; set; }


        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Lütfen Parola Giriniz")]
        public string Password { get; set; }

        [Display(Name = "Parola Tekrar")]
        [Compare("Password", ErrorMessage = "Parola Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı giriniz")]
        public string UserName { get; set; }
    


}
}
