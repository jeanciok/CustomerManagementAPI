namespace CustomerManagement.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Attachment(string name, string fileUrl)
        {
            Name = name;
            FileUrl = fileUrl;
        }

        public string Name { get; set; }
        public string FileUrl { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
