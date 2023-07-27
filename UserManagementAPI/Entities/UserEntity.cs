using UserManagementAPI.Dtos;

namespace UserManagementAPI.Entities
{
    public class UserEntity
    {
        public long? id { get; set; }

        public string name { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public bool enable { get; set; }

        public UserDto toDto()
        {
            return new UserDto()
            {
                Id = id ?? throw new Exception("El id no puede ser null. (EP)"),
                Name = name,
                Lastname = lastname,
                Email = email,
                Enable = enable

            };
        }
    }
}
