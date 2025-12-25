using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApplication1.Models; // Replace with your namespace

namespace WebApplication1.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required, EmailAddress, Display(Name = "Email")]
            public string Email { get; set; }

            [Required, DataType(DataType.Password), Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password), Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Role")]
            public string SelectedRole { get; set; }
        }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public async Task OnGetAsync()
        {
            // Available roles
            Roles = new List<SelectListItem>
            {
                new SelectListItem("Admin","Admin"),
                new SelectListItem("Student","Student"),
                new SelectListItem("Staff","Staff")
            };

            // Ensure roles exist
            foreach (var role in new[] { "Admin", "Student", "Staff" })
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                // Assign role (default = Student)
                var role = string.IsNullOrEmpty(Input.SelectedRole) ? "Student" : Input.SelectedRole;
                await _userManager.AddToRoleAsync(user, role);

                // Automatically confirm email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, token);

                _logger.LogInformation("User registered successfully.");
                return RedirectToPage("/Account/Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}
