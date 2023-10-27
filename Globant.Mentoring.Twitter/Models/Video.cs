namespace Globant.Mentoring.Twitter.Models
{
    public class Video:FileEmbed
    {
        public int Id { get; set; }
        public int Length { get; set; }

        public Video(int fileId, int length)
        {
            Id = fileId;
            Length = length;
        }
        public Video() { }
    }
}
