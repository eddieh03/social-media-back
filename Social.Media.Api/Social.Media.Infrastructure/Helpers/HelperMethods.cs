﻿using System.Security.Cryptography;

namespace Social.Media.Infrastructure.Helpers;

public static class HelperMethods
{
    public static string CreateMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();
        }
    }
}
