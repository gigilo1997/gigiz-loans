using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PersonalNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiresAt { get; private set; }

    public virtual ICollection<UserLoan> Loans { get; private set; } = new List<UserLoan>();

    private AppUser(
        string userName,
        string firstName,
        string lastName,
        string personalNumber,
        DateTime dateOfBirth)
    {
        UserName = userName.Trim();
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        PersonalNumber = personalNumber.Trim();
        DateOfBirth = dateOfBirth.Date;
    }

    public static AppUser Create(
        string userName,
        string firstName,
        string lastName,
        string personalNumber,
        DateTime dateOfBirth)
    {
        return new AppUser(userName, firstName, lastName, personalNumber, dateOfBirth);
    }

    public void UpdatePersonalInfo(
        string firstName,
        string lastName,
        string personalNumber,
        DateTime dateOfBirth)
    {
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        PersonalNumber = personalNumber.Trim();
        DateOfBirth = dateOfBirth.Date;
    }

    public void UpdateRefreshToken(string refreshToken, DateTime expiresAt)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiresAt = expiresAt;
    }
}
