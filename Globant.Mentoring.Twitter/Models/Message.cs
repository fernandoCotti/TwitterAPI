namespace Globant.Mentoring.Twitter.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTime DateSent { get; set; }
        public User Receptor { get; set; }

        public Message(int messageId, string messageContent, DateTime dateSent, User receptor)
        {
            MessageId = messageId;
            MessageContent = messageContent;
            DateSent = dateSent;
            Receptor = receptor;
        }
    }
}
