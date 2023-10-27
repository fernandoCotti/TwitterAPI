namespace Globant.Mentoring.Twitter.Models
{
    public class FileEmbed
    {
        public string FileId { get; set; }
        public char FileType { get; set; }
        public int Size { get; set; }
        public DateTime DateCreated { get; set; }

        public FileEmbed(string fileId, char fileType, int size, DateTime dateCreated)
        {
            FileId = fileId;
            FileType = fileType;
            Size = size;
            DateCreated = dateCreated;
        }
        public FileEmbed() { }  
    }
}
