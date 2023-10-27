namespace Globant.Mentoring.Twitter.DTOs
{
    public class CreateUserDTO
    {
        public string Username { get; set; }

        public CreateUserDTO() { }
        public CreateUserDTO(string username)
        {
            Username = username;
        }
    }
}
