using System.Data.Entity;

namespace TestTaskNavicon.Models
{
    public class ContactDBContext : DbContext
    {
        public DbSet<Contact> contacts { get; set; }
    }
}
