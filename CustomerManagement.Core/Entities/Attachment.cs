namespace CustomerManagement.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Attachment() { }

        public Attachment(string name, string uRLFile, Guid customerId, Customer customer)
        {
            Name = name;
            URLFile = uRLFile;
            CustomerId = customerId;
            Customer = customer;
        }

        public string Name { get; set; }
        public string URLFile { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
