using ImageMLConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageMLConsole
{
    internal class ImageContext: DbContext
    {
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ImageDB;Trusted_Connection=True;");
        }
    }
}
