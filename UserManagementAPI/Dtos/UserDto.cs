namespace UserManagementAPI.Dtos
{
    public class UserDto
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public bool Enable { get; set; }
    }
}
