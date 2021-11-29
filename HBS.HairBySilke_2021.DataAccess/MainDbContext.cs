using HBS.HairBySilke_2021.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HBS.HairBySilke_2021.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options){}
        public virtual DbSet<TreatmentEntity> Treatments { get; set; }
    }
}