namespace Globant.Mentoring.Twitter.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public DateTime DatePosted { get; set; }
        public int FkUserId { get; set; }
        //public User FkUserId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public Post(int postid, string postcontent, DateTime dateposted, int poster, List<Tag> tags)
        {
            PostId = postid;
            PostText = postcontent;
            DatePosted = dateposted;
            FkUserId = poster;
            Tags = tags;
        }
        
        public Post()
        {

        }
    }
}
