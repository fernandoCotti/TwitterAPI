namespace Globant.Mentoring.Twitter.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public DateTime Date_Created { get; set; }

        public UserDTO() { }
        public UserDTO(string username, DateTime date_created) {
            Username= username;
            Date_Created = date_created;
        }
    }
}
