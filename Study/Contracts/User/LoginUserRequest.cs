using System.ComponentModel.DataAnnotations;

namespace Study.Contracts.User
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required, DataType(DataType.Password)] string Password);
}
