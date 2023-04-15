namespace Domain.Auth;

public interface ICurrentUser
{
    bool IsAuthenticated();
    Guid? GetUserId();
}
