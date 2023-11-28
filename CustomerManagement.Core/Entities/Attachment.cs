namespace CustomerManagement.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Attachment() { }

        public Attachment(string name, string urlFile)
        {
            Name = name;
            UrlFile = urlFile;
        }

        public string Name { get; set; }
        public string UrlFile { get; set; }
        //public Guid CustomerId { get; set; }
        //public Customer Customer { get; set; }
    }
}
