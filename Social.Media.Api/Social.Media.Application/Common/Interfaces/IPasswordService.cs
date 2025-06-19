namespace Social.Media.Application.Common.Interfaces;
public interface IPasswordService
{
    bool VerifyPassword(string providedPassword, string salt, string storedHash);
}
