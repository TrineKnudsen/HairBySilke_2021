using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test.Models
{
    public class AdminTest
    {
        private readonly Admin _admin;
        public AdminTest()
        {
            _admin = new Admin(); 
        }
        [Fact]
        public void Admin_CanBeInitialized()
        {
            Assert.NotNull(_admin);
        }

        [Fact]
        public void Admin_SetId_StoresId()
        {
            _admin.Id = 1;
            Assert.Equal(1, _admin.Id);
        }

        [Fact]
        public void Admin_Id_MustBeInt()
        {
            Assert.True(_admin.Id is int);
        }
    }
}