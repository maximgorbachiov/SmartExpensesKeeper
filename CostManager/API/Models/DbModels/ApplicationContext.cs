using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Models.DbModels
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            string[] names = new string[] { "Ivan", "Maksim", "Kirill" };

            Database.EnsureCreated();
            
            for(int i = 0; i < names.Length; i++)
            {
                var user = this.Users.FirstOrDefault(u => u.Name == names[i]);
                if (user == null)
                {
                    this.Users.Add(new User { Id = i + 1, Name = names[i] });
                }
            }

        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
