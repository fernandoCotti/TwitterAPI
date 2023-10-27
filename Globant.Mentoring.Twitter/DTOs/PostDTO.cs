namespace Globant.Mentoring.Twitter.DTOs
{
    public class PostDTO
    {

        public string? Post_Text { get; set; }
        public DateTime? Date_Posted { get; set; }

        public PostDTO() { }
        public PostDTO(string post_text, DateTime? dateposted)
        {
            Post_Text = post_text;
            Date_Posted = dateposted;
        }
    }
}
