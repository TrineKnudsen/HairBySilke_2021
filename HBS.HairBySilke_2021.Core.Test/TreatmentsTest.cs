using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class TreatmentsTest
    {
        [Fact]
        public void Treatment_CanBeInitialized()
        {
            var treatment = new Treatment();
            Assert.NotNull(treatment);
        }
        
        [Fact]
        public void Product_SetId_StoresId()
        {
            var treatment = new Treatment();
            treatment.Id = 1;
            Assert.Equal(1, treatment.Id);
        }

        [Fact]
        public void Product_SetName_StoreNamesString()
        {
            var treatment = new Treatment();
            treatment.Name = "Helfarve - langt hår";
            Assert.Equal("Helfarve - langt hår", treatment.Name);
        }
    }
    
    
}