using System;
using System.Security.Cryptography;

namespace AeroDb.Core
{
    public static class CommonHelper
    {
        public static string EnsureNotNull(string str)
        {
            return str ?? string.Empty;
        }

        public static int GenerateRandomInteger(int min = 0, int max = int.MaxValue)
        {
            var randomNumberBuffer = new byte[10];
            RandomNumberGenerator.Create().GetBytes(randomNumberBuffer);
            return new Random(BitConverter.ToInt32(randomNumberBuffer, 0)).Next(min, max);
        }
    }
}