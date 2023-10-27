namespace Globant.Mentoring.Twitter.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string? TagDescription { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public Tag(int tagId, string tagName)
        {
            TagId = tagId;
            TagName = tagName;
        }

        public Tag(int tagId, string tagName, string? tagDescription)
        {
            TagId = tagId;
            TagName = tagName;
            TagDescription = tagDescription;
        }

        public Tag(int tagId, string tagName, string? tagDescription, List<Post> posts)
        {
            TagId = tagId;
            TagName = tagName;
            TagDescription = tagDescription;
            Posts = posts;
        }

        public Tag()
        {

        }
    }
}
