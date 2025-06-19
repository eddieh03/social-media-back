using Social.Media.Application.Common.Interfaces;
using Social.Media.Infrastructure.Helpers;

namespace Social.Media.Infrastructure.Services.Authentication;

public class PasswordService : IPasswordService
{
    public bool VerifyPassword(string providedPassword, string salt, string storedHash)
    {
        var hashToVerify = HelperMethods.CreateMD5(salt + providedPassword);
        return hashToVerify == storedHash;
    }
}
