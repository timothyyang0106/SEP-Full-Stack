using System.Security.Claims;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserService _userService;

    public AccountController(ICurrentUserService currentUserService,
        IUserService userService,
        IAccountService accountService)
    {
        _currentUserService = currentUserService;
        _userService = userService;
        _accountService = accountService;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EditProfile()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(UserProfileRequestModel profileRequestModel)
    {
        if (!ModelState.IsValid) return View();

        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Upload(IFormFile profileImage)
    {
        if (_currentUserService.UserId == null) return RedirectToAction("Login");
        var userProfile = new UserProfileRequestModel
        {
            Id = _currentUserService.UserId,
            FullName = _currentUserService.FullName,
            File = profileImage
        };

        await _userService.UploadUserProfilePicture(userProfile);
        return RedirectToAction("Profile");
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterRequestModel registerModel)
    {
        if (!ModelState.IsValid) return View();
        await _accountService.CreateUser(registerModel);
        return RedirectToAction("Login");
    }

    [HttpGet]
    public ActionResult Login()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated) return LocalRedirect("~/");
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<ActionResult> Login(UserLoginRequestModel loginRequest, string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        if (!ModelState.IsValid) return View();

        var user = await _accountService.ValidateUser(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.GivenName, user.FirstName),
            new(ClaimTypes.Surname, user.LastName),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        if (user.Roles != null) claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return LocalRedirect(returnUrl);
    }

    [HttpGet]
    public IActionResult Profile()
    {
        return View();
    }
}