namespace Globant.Mentoring.Twitter.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string URL { get; set; }

        public Link(int id, string uRL)
        {
            Id = id;
            URL = uRL;
        }
        public Link()
        {

        }
    }
}
