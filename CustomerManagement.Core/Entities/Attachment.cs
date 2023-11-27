namespace CustomerManagement.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Attachment(string name, string urlFile)
        {
            Name = name;
            URLFile = urlFile;
        }

        public string Name { get; set; }
        public string URLFile { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
