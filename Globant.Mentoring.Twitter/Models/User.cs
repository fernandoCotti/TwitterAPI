using Microsoft.Extensions.Hosting;

namespace Globant.Mentoring.Twitter.Models
{
    public class User
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public User(string username, int userId, DateTime dateCreated, DateTime lastLoginDate, bool isActive)
        {
            Username = username;
            UserId = userId;
            DateCreated = dateCreated;
            LastLoginDate = lastLoginDate;
            IsActive = isActive;
        }
        public User()
        {

        }

        public bool getIsActive()
        {
            var diff = DateTime.Now - LastLoginDate;
            if (diff.Days > 180)
                return false;
            else
                return true;
        }

        public void setIsActive()
        {
            var diff = DateTime.Now - LastLoginDate;
            if (diff.Days > 180)
                this.IsActive = false;
            else
                this.IsActive = true;
        }
    }
}
