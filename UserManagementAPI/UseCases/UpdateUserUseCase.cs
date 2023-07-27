using UserManagementAPI.Dtos;
using UserManagementAPI.Repositories;

namespace UserManagementAPI.UseCases
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly UserManagementContext _userManagementContext;

        public UpdateUserUseCase(UserManagementContext userManagementContext)
        {
            _userManagementContext = userManagementContext;
        }

        public async Task<UserDto?> Execute(UserDto user)
        {
            var entity = await _userManagementContext.GetUser(user.Id);

            if (entity == null) 
                return null;

            entity.name = user.Name;
            entity.email = user.Email;
            entity.lastname = user.Lastname;
            entity.enable = user.Enable;

            await _userManagementContext.UpdateUser(entity);

            return entity.toDto();
            
        }
    }
}
