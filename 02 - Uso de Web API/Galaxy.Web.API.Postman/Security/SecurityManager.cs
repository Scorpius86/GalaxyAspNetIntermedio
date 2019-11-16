using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Web.API.Postman.Security
{    
    public class SecurityManager
    {
        public JwtSettings _jwtSettings { get; set; }

        public SecurityManager( JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string BuildJwtToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            List<Claim> jwtClaims = new List<Claim>();
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, "Erick"));
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            jwtClaims.Add(new Claim("Rol", "Administrator"));

            var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: jwtClaims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.MinuteExpiration),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
