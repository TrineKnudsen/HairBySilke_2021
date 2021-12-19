using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test.Models
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
        public void Treatment_SetId_StoresId()
        {
            var treatment = _helper.GetTreatment(1);
            Assert.Equal(1, treatment.Id);
        }

        [Fact]
        public void Treatment_SetName_StoreNamesString()
        {
            var treatment = new Treatment();
            treatment.TreatmentName = "Helfarve - langt hår";
            Assert.Equal("Helfarve - langt hår", treatment.TreatmentName);
        }

        [Fact]
        public void Treatment_AttributePrice_IsOfTypeInt()
        {
            Assert.True(_helper.GetTreatment(1).Price is int);
        }

        [Fact]
        public void Treatment_AttriDuration_IsOftypeInt()
        {
            Assert.True(_helper.GetTreatment(1).Duration is int);
        }
    }
    
    
}