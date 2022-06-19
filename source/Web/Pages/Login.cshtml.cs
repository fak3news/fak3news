using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fak3News.Domain.Models;
using Fak3News.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Fak3News.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<Admin> userManager;
        private readonly SignInManager<Admin> signInManager;
        private readonly AppDbContext dbContext;

        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(UserManager<Admin> userManager, SignInManager<Admin> signInManager, AppDbContext dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var doInitialLogin = !dbContext.Users.Any();

            if (doInitialLogin)
            {
                var admin = new Admin() { Email = Email, UserName = Email };
                await userManager.CreateAsync(admin, Password);
            }

            var result = await signInManager.PasswordSignInAsync(Email, Password, true, false);

            if (result.Succeeded)
                return RedirectToPage("Admin");
            else
                return Page();
        }
    }
}
