namespace HBS.HairBySilke_2021.Security
{
    public interface IAuthDbSeeder
    {
        void SeedDevelopment();

        void SeedProduction();
    }
}