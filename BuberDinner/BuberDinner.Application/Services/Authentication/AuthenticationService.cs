using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenrator _jwtTokenGenrator;

        public AuthenticationService(IJwtTokenGenrator jwtTokenGenrator)
        {
            _jwtTokenGenrator = jwtTokenGenrator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName","email", "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            Guid id = Guid.NewGuid();
            var token = _jwtTokenGenrator.GenerateToken(id, firstName, lastName);
            return new AuthenticationResult(id, firstName, lastName, email, token);
        }
    }
}
