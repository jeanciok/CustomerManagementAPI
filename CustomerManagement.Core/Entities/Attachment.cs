namespace CustomerManagement.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Attachment(Guid id, string name, string fileUrl, string fileType, Guid customerId)
        {
            Id = id;
            Name = name;
            FileUrl = fileUrl;
            FileType = fileType;
            CreatedAt = DateTime.Now;
            CustomerId = customerId;
        }

        public string Name { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
