namespace Study.Domain.Models
{
    public class User
    {
        private User(Guid id, string userName, string email, string passwordHash)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        }
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public static User Create(Guid id, string userName, string email, string passwordHash)
        {
            return new User(id, userName, email, passwordHash);
        }
    }
}
