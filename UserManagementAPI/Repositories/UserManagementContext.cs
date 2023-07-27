using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserManagementAPI.Dtos;
using UserManagementAPI.Entities;

namespace UserManagementAPI.Repositories
{
    public class UserManagementContext : DbContext
    {
        //Contructor para la clase padre
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {
        
        }

        //Conexion a la tabla en la base de datos. La relacion debe tener el mismo nombre que la tabla en la bd.
        public DbSet<UserEntity> gestion_usuarios { get; set; }

        //Metodo para traer un User desde la bd a partir del id.
        public async Task<UserEntity> GetUser(long id)
        {
            return await gestion_usuarios.FirstAsync(x => x.id == id);
        }

        //Metodo para agregar un User a la bd.
        public async Task<UserEntity> AddUser(CreateUserDto userDto)
        {

            UserEntity user = new UserEntity()
            {
                id = null,
                name = userDto.Name,
                lastname = userDto.Lastname,
                email = userDto.Email,
                enable = userDto.Enable,
            };

            EntityEntry<UserEntity> response = await gestion_usuarios.AddAsync(user);
            await SaveChangesAsync();

            return await GetUser(response.Entity.id ?? throw new Exception("No se pudo guardar el usuario."));
        }

        //Metodo para borrar un User de la bd.
        public async Task<bool> DeleteUser(long id)
        {
            UserEntity entity = await GetUser(id);
            if (entity == null)
            {
                throw new Exception("No se pudo guardar el usuario.");
            }

            gestion_usuarios.Remove(entity);
            SaveChanges();
            return true;
        }

        public async Task<bool> UpdateUser(UserEntity userEntity)
        {
            gestion_usuarios.Update(userEntity);
            await SaveChangesAsync();

            return true;
        }

    }
}
