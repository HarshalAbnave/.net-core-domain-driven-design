namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenrator
    {
        string GenerateToken(Guid Id, string FirstName, string LastName);
    }
}
