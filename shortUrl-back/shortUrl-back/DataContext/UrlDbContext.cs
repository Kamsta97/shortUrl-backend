namespace shortUrl_back.DataContext
{
    public class UrlDbContext : DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> options) :
            base(options)
        {

        }

        public DbSet<Url> Url { get; set; }
    }
}

