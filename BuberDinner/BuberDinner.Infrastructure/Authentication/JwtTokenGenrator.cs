using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenrator : IJwtTokenGenrator
    {
        private readonly ILogger<JwtTokenGenrator> _logger;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenrator(ILogger<JwtTokenGenrator> logger,
                                IDateTimeProvider dateTimeProvider,
                                IOptions<JwtSettings> jwtSettings)
        {
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Guid Id, string FirstName, string LastName)
        {
            SigningCredentials? siginingCredentials = new(
                                                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                                                          SecurityAlgorithms.HmacSha256);

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, LastName),
            };

            JwtSecurityToken? securityToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: siginingCredentials,
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes));

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
