using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SIA.Data;
using SIA.Models;

namespace SIA.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _dbcontext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext dbcontext,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _dbcontext = dbcontext;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "User Name")]
            public string UserName { get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public bool Estado { get; set; }
            public string Funcao { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ViewData["funcoes"] = _roleManager.Roles.ToList();
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.UserName, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userManager.AddToRoleAsync(user, Input.Funcao= "Client");//Client ou SuperAdmin



                    Quadrante Quadrante1 = new Quadrante { Nome = "Por inserir", Pontuacao = 0, Cor = "Branco",GrupoId= 1 };
                    _dbcontext.Quadrante.Add(Quadrante1);
                    await _dbcontext.SaveChangesAsync();
                    Quadrante Quadrante2 = new Quadrante { Nome = "Por inserir", Pontuacao = 0, Cor = "Branco", GrupoId = Quadrante1.GrupoId };
                    _dbcontext.Quadrante.Add(Quadrante2);
                    await _dbcontext.SaveChangesAsync();
                    Quadrante Quadrante3 = new Quadrante { Nome = "Por inserir", Pontuacao = 0, Cor = "Branco", GrupoId = Quadrante1.GrupoId };
                    _dbcontext.Quadrante.Add(Quadrante3);
                    await _dbcontext.SaveChangesAsync();
                    Quadrante Quadrante4 = new Quadrante { Nome = "Por inserir", Pontuacao = 0, Cor = "Branco", GrupoId = Quadrante1.GrupoId };
                    _dbcontext.Quadrante.Add(Quadrante4);
                    await _dbcontext.SaveChangesAsync();

                    Tecnica newTecnica = new Tecnica { Nome = "Inserir nome", QuadranteId =Quadrante1.GrupoId};
                    _dbcontext.Tecnica.Add(newTecnica);
                    await _dbcontext.SaveChangesAsync();

                    Utilizador newUtilizador = new Utilizador {Nome = user.UserName, Email = user.Email, Estado = true, Funcao = Input.Funcao, Password=user.PasswordHash,TecnicaId=newTecnica.Id };
                    _dbcontext.Utilizador.Add(newUtilizador);
                    await _dbcontext.SaveChangesAsync();



                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["roles"] = _roleManager.Roles.ToList();
            return Page();
        }
    }
}
