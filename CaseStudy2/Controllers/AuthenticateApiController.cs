using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiCaseStudy.Model;

namespace WebApiCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateApiController : Controller
    {

        public List<UserModel> usersList = null;
        public AuthenticateApiController()
        {
            usersList = new List<UserModel>()
            {
                new UserModel() { UserId = 1, UserName = "Admin", Password = "Admin123", Role = "Admin" },
                new UserModel() { UserId = 2, UserName = "Scott", Password = "Scott123", Role = "User" }
            };
        }
        [HttpPost]
        public IActionResult Login(LoginModel requestUser)
        {
            UserModel userObj = usersList.Where(x => x.UserName == requestUser.UserName && x.Password == requestUser.Password).FirstOrDefault();

            if (userObj != null)
            {
                string tokenStr = GenerateJSONWebToken(userObj);
                return Ok(new { token = tokenStr });
            }
            else
            {
                return BadRequest("Invalid user id or password");
            }
        }

        private string GenerateJSONWebToken(UserModel userObj)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            List<Claim> authClaims = new List<Claim>
            {
                    new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userObj.UserId)),
                    new Claim(ClaimTypes.Name, userObj.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  // (JWT ID) Claim
                    new Claim(ClaimTypes.Role, userObj.Role)
             };

            JwtSecurityToken token = new JwtSecurityToken(
                        issuer: "mySystem",
                        audience: "myUsers",
                        claims: authClaims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
