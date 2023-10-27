namespace Globant.Mentoring.Twitter.Models
{
    public class Image : FileEmbed
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Image(int id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
        }
        public Image() { }  
    }
}
