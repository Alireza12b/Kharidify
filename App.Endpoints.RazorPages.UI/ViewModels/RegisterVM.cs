using App.Domain.Core.Products.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class RegisterVM
    {
        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [StringLength(16, ErrorMessage = "* شماره همراه صحیح نیست")]
        [Display(Name = "شماره همراه")]
        public string Phone { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [EmailAddress(ErrorMessage = "* آدرس ایمیل معتبر نمی باشد")]
        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [StringLength(16, ErrorMessage = "* کلمه عبور باید حداقل 4 و حداکثر 16 کاراکتر باشد", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password), ErrorMessage = "* کلمه عبور و تکرار آن باید برابر باشند")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

        [BindProperty]
        public string? City { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [Display(Name = "آدرس دقیق")]
        public string? AddressDetail { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد نکرده اید ")]
        [Display(Name = "کد پرستی")]
        public string? PostalCode { get; set; }
    }
}
