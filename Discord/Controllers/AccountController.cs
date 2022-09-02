using Discord.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Discord.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }


        [Route("~/signin")]
        public async Task<IActionResult> Login() => View(await HttpContext.GetExternalProvidersAsync());


        [HttpPost("~/signin")]
        public async Task<IActionResult> Index([FromForm] string provider)
        {
            // Note: the "provider" parameter corresponds to the external
            // authentication provider choosen by the user agent.
            if (string.IsNullOrWhiteSpace(provider))
            {
                return BadRequest();
            }

            if (!await HttpContext.IsProviderSupportedAsync(provider))
            {
                return BadRequest();
            }

            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
            var challengeResult = Challenge(new AuthenticationProperties { RedirectUri = "/" }, provider);
            return challengeResult;
        }

        [Route("signin-discord")]
        public async Task<IActionResult> DiscordSignIn(string code, string state)
        {
            var user = new IdentityUser(code[..5] )
            {
                Email = code[..5] + "@" + code[..5]  + ".de"
            };
            var result = await _userManager.CreateAsync(user, "Test12345!");

            if (result.Succeeded)
            {
                user = await _userManager.FindByNameAsync(code[..5]);

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, "Test12345!", true);

                if (signInResult.Succeeded)
                {
                    signInResult = await _signInManager.PasswordSignInAsync(user, "Test12345!", true, true);
                    
                }
            }

            bool isSignedIn = _signInManager.IsSignedIn(HttpContext.User);

            if (isSignedIn)
                return RedirectToAction("Success", "Home");
            else
                return RedirectToAction(nameof(Index));
        }
    }
}
