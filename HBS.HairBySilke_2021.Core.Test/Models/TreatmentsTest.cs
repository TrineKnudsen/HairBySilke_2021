using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class TreatmentsTest
    {
        private readonly TestHelper _helper;

        public TreatmentsTest()
        {
            _helper = new TestHelper();
        }
        
        [Fact]
        public void Treatment_CanBeInitialized()
        {
            Assert.NotNull(_helper.GetTreatment());
        }
        
        [Fact]
        public void Product_SetId_StoresId()
        {
            var treatment = _helper.GetTreatment(1);
            Assert.Equal(1, treatment.Id);
        }

        [Fact]
        public void Product_SetName_StoreNamesString()
        {
            var treatment = new Treatment();
            treatment.TreatmentName = "Helfarve - langt hår";
            Assert.Equal("Helfarve - langt hår", treatment.TreatmentName);
        }
    }
    
    
}