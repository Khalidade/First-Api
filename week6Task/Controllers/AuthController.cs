using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace week6Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        private class ContactsInfoUser
        {
            public int UserId { get; set; }
            public string? UserName { get; set; }
            public string? Address { get; set; }
            public string? Role { get; set; }

            public ContactsInfoUser(int userId, string? userName, string? address, string? role)
            {
                UserId = userId;
                UserName = userName;
                Address = address;
                Role = role;
            }
        }

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("register")]
        public ActionResult<string> Register(AuthenticationRequestBody authenticationRequestBody)
        {
            // Register user logic (you should store user details, including role, in your database)
            // For demonstration purposes, assume "admin" or "user" based on the input
            string role = authenticationRequestBody.UserName?.ToLower() == "admin" ? "admin" : "user";

            var user = new ContactsInfoUser(1, authenticationRequestBody.UserName, "ibadan", role);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public ActionResult<string> Login(AuthenticationRequestBody authenticationRequestBody)
        {
            // Authenticate user based on username and password (actual authentication logic)
            var user = ValidateUserCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            // Create and return JWT token
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.UserName));
            claimsForToken.Add(new Claim("address", user.Address));
            claimsForToken.Add(new Claim(ClaimTypes.Role, user.Role));

            var jwtSecurityToken = new JwtSecurityToken(_configuration["Authentication:Issuer"], _configuration["Authentication:Audience"], claimsForToken, DateTime.UtcNow, DateTime.UtcNow.AddHours(1), signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(tokenToReturn);
        }

        private ContactsInfoUser ValidateUserCredentials(string? userName, string? password)
        {
            // In a real-world scenario, validate user credentials and fetch user details (including role) from your database
            // For demonstration purposes, assume "admin" or "user" based on the username
            if (userName == "admin" && password == "adminpassword")
            {
                return new ContactsInfoUser(1, "admin", "ibadan", "admin");
            }
            else if (userName == "user" && password == "userpassword")
            {
                return new ContactsInfoUser(2, "user", "lagos", "user");
            }

            return null;
        }
    }
}
