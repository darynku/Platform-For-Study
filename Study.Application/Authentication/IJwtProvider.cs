using Study.Domain.Models;

namespace Study.Infrastructure.Authentication
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}