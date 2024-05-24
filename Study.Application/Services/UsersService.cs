using Study.Application.Authentication;
using Study.Domain.Interfaces.Repository;
using Study.Domain.Models;
using Study.Infrastructure.Authentication;
namespace Study.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;
        public UsersService(IUsersRepository usersRepository,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, email, hashedPassword);

            await _usersRepository.Create(user);

        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.Generate(user);
            return token;
        }
    }
}
