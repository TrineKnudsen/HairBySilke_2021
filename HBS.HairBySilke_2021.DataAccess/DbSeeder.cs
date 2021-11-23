namespace HBS.HairBySilke_2021.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
        }
    }
}