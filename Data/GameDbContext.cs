using Microsoft.EntityFrameworkCore;

namespace HumanVSAi.Api.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        // Veritabanındaki "Images" tablosunu "Image" sınıfımıza bağlıyoruz.
        public DbSet<Image> Images { get; set; }
    }
}
