using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Study.Domain.Interfaces.Repository;
using Study.Domain.Models;
using Study.Persistence.Entities;

namespace Study.Persistence.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UsersRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
     
        }

        public async Task Create(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };
            
            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();


        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }
    }
}
