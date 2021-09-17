using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VersionClient.Models;

namespace VersionClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly ILogger<AccountController> _logger;



        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        //POST: Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser model)
        {

            //validar a entrada de uma nova identidade de usuário e registrá - la em nosso banco de dados.
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("Cadastro realizado com sucesso!");
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Login Inválido");
            }

            return View(model);
        }

        //GET: Account/Login
        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Operador Conectado");
                    return RedirectToAction("Index", "Clients");
                }
                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Operador Desconectado");
            return View();
        }
    }
}
