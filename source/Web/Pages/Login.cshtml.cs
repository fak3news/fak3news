using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Fak3News.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak3News.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<Admin> userManager;
        private readonly SignInManager<Admin> signInManager;

        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(UserManager<Admin> userManager, SignInManager<Admin> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await signInManager.PasswordSignInAsync(Email, Password, true, false);
            if (result.Succeeded)
                return RedirectToPage("Admin");
            else
                return Page();
        }

    }
}
