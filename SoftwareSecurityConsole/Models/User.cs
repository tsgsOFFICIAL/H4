namespace SoftwareSecurityConsole.Models
{
    internal class User
    {
        internal long Id { get; set; }
        internal string? Username { get; set; }
        internal string? Password { get; set; }
        internal DateTime CreationTime { get; set; }
        internal DateTime? LastLoginTime { get; set; }
        internal bool Banned { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Password: {Password}, CreationTime: {CreationTime}, LastLoginTime: {LastLoginTime}, Banned: {Banned}";
        }
    }
}
