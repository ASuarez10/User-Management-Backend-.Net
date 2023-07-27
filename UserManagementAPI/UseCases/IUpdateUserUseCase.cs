using UserManagementAPI.Dtos;

namespace UserManagementAPI.UseCases
{
    public interface IUpdateUserUseCase
    {
        Task<UserDto?> Execute(UserDto user);
    }
}
