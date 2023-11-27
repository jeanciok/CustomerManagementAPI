namespace CustomerManagement.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Attachment(string name, string uRLFile, Customer customer)
        {
            Name = name;
            URLFile = uRLFile;
            Customer = customer;
        }

        public string Name { get; set; }
        public string URLFile { get; set; }
        public Customer Customer { get; set; }
    }
}
