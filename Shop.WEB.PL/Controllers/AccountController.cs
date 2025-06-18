using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                Address = model.Address,
                BirthDate = model.BirthDate
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Ok(new { message = "User registered successfully" });

            foreach (var error in result.Errors)
                ModelState.AddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }
    }

    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters")]
        public string Password { get; set; }
    }
}
