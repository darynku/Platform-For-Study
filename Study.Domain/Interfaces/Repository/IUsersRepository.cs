using Study.Domain.Models;

namespace Study.Domain.Interfaces.Repository
{
    public interface IUsersRepository
    {
        Task Create(User user);
        Task<User> GetByEmail(string email);
    }
}