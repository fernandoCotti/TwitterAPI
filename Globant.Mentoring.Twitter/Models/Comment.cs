namespace Globant.Mentoring.Twitter.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }

        public User Commenter { get; set; }
        public Post PostCommented { get; set; }
        public DateTime DateCommented { get; set; }

        public Comment(int commentId, string commentContent, User commenter, Post postCommented, DateTime dateCommented)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            Commenter = commenter;
            PostCommented = postCommented;
            DateCommented = dateCommented;
        }
        public Comment() { }
    }
}
