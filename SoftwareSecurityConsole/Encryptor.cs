namespace SoftwareSecurityConsole
{
    internal static class Encryptor
    {
        internal static string Hash(string plainText, int cost = 10)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainText, workFactor: cost);
        }
        internal static bool Verify(string plainText, string hashText)
        {
            return BCrypt.Net.BCrypt.Verify(plainText, hashText);
        }
        internal static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(plainTextBytes);
        }
        internal static string Base64Decode(string base64EncodedData)
        {
            byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
