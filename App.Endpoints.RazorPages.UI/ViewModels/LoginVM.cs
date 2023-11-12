using System.ComponentModel.DataAnnotations;

namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        [EmailAddress(ErrorMessage = "* آدرس ایمیل معتبر نمی باشد")]
        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }


        public bool RememberMe { get; set; }
    }
}
