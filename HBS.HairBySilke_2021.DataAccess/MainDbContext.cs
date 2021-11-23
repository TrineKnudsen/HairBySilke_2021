using Microsoft.EntityFrameworkCore;

namespace HBS.HairBySilke_2021.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options){}
    }
}