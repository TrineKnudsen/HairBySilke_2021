using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class TreatmentsTest
    {
        private Treatment _treatment;
        public TreatmentsTest()
        {
            _treatment = new Treatment();
        }
        
        /*
         * Testing if the treatment model can be initialized.
         */
        [Fact]
        public void Treatment_CanBeInitialized()
        {
            Assert.NotNull(_treatment);
        }
        
        /*
         * Tests if we can save an id to treatment and
         * that it will be stored in the treatment.
         */
        [Fact]
        public void Treatment_Id_MustBeInt()
        {
            Assert.True(_treatment.Id is int);
        }
        
        /*
         * Tests if we can save an id to treatment and
         * that it will be stored in the treatment.
         */
        [Fact]
        public void Treatment_SetId_StoresId()
        {
            _treatment.Id = 1;
            Assert.Equal(1, _treatment.Id);
        }

        /**
         * Tests if we can set a treatment name to a treatment and that
         * it will be saved as a string in the treatment.
         */
        [Fact]
        public void Treatment_SetName_StoreNameAsString()
        {
            _treatment.TreatmentName = "Bundfarve";
            Assert.Equal("Bundfarve", _treatment.TreatmentName);
        }
    }
}