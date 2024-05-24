using System.ComponentModel.DataAnnotations;

namespace Study.Contracts.User
{
    public record RegisterUserRequest(
        [Required] string UserName, 
        [Required] string Email,
        [Required, DataType(DataType.Password)] string Password);    
}
