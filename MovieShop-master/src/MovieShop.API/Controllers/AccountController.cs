using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MovieShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IConfiguration _config;
    private readonly IUserService _userService;

    public AccountController(IUserService userService, IConfiguration config, IAccountService accountService)
    {
        _userService = userService;
        _config = config;
        _accountService = accountService;
    }

    /// <summary>
    ///     Creates a new User
    /// </summary>
    /// <param name="user"></param>
    /// <returns>A newly created User</returns>
    /// <response code="201">Returns the newly created user</response>
    /// <response code="400">If the validation fails </response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("register")]
    public async Task<ActionResult<UserRegisterResponseModel>> RegisterUserAsync(
        [FromBody] UserRegisterRequestModel user)
    {
        var createdUser = await _accountService.CreateUser(user);
        return CreatedAtRoute("GetUser", new { controller = "user", id = createdUser.Id },
            $"User {createdUser.Id} is created");
    }

    /// <summary>
    ///     Check if the email already exists in the system
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("check-email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> EmailExists(
        [FromQuery] [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        string email)
    {
        var emailExists = await _userService.CheckEmailExists(email);
        return Ok(new { emialExist = emailExists });
    }

    /// <summary>
    ///     Validated the user's email/password and generates JWT
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns>Json Web Token(JWT) is correct email/password</returns>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> LoginAsync([FromBody] UserLoginRequestModel loginRequest)
    {
        var user = await _accountService.ValidateUser(loginRequest.Email, loginRequest.Password);
        return Ok(new { token = GenerateToken(user) });
    }

    private string GenerateToken(UserLoginResponseModel user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };
        if (user.Roles != null)
        {
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            if (user.Roles.Any(r => r.Name is "Admin" or "SuperAdmin"))
                claims.Add(new Claim("isAdmin", true.ToString(), ClaimValueTypes.Boolean));
        }

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["PrivateKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var expires = DateTime.UtcNow.AddHours(_config.GetValue<double>("ExpirationHours"));

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identityClaims,
            Expires = expires,
            SigningCredentials = credentials,
            Issuer = _config["Issuer"],
            Audience = _config["Audience"]
        };

        var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(encodedJwt);
    }
}