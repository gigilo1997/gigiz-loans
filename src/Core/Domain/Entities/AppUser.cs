using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? PersonalNumber { get; private set; }
    public DateTime? DateOfBirth { get; private set; }

    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiresAt { get; private set; }

    public static AppUser Create(
        string userName,
        string firstName,
        string lastName,
        string personalNumber,
        DateTime dateOfBirth)
    {
        return new AppUser
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            PersonalNumber = personalNumber,
            DateOfBirth = dateOfBirth
        };
    }

    public void UpdatePersonalInfo(
        string firstName,
        string lastName,
        string personalNumber,
        DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth;
    }

    public void UpdateRefreshToken(string refreshToken, DateTime expiresAt)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiresAt = expiresAt;
    }
}
