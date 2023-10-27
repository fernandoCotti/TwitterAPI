namespace Globant.Mentoring.Twitter.Models
{
    public class Bookmark
    {
        public int BookmarkId { get; set; }
        public DateTime DateSaved { get; set; }
        public User Saver { get; set; }
        public Post PostSaved { get; set; }

        public Bookmark(int bookmarkID, DateTime datesaved, User saver, Post postsaved)
        {
            BookmarkId = bookmarkID;
            DateSaved = datesaved;
            Saver = saver;
            PostSaved = postsaved;
        }
        public Bookmark() { }
    }
}
