using Application.Interfaces.Jwtservices;
using Application.Interfaces.UnitOfWorkRepositories;
using Domain.Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Peristance.Extensions
{
    public class JwtService : IJwsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public JwtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> GenrateJwt(int userId)
        {
            var user = await _unitOfWork.Repositary<User>().GetByID(userId);

            var Customclaims = new List<Claim>
            {
       new Claim("Id", user.Id.ToString()),
       new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Email, user.Email)
             };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345jhgiu243yqiuyiu4y"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: Customclaims,
              expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}

