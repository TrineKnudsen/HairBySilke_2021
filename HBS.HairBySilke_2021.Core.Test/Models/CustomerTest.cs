using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test.Models
{
    public class CustomerTest
    {
        private readonly TestHelper _helper;

        public CustomerTest()
        {
            _helper = new TestHelper();
        }
        
        [Fact]
        public void Customer_CanBeInitialized()
        {
            Assert.NotNull(_helper.GetCustomer());
        }

        [Fact]
        public void Customer_Id_MustBeInt()
        {
            Assert.True(_helper.GetTreatment().Id is int);
        }
        
        [Fact]
        public void Customer_SetId_StoresId()
        {
            var customer = _helper.GetCustomer(1);
            Assert.Equal(1, customer.Id);
        }

        [Fact]
        public void Customer_SetName_StoreNamesString()
        {
            var customer = new Customer();
            customer.Name = "Isabella";
            Assert.Equal("Isabella", customer.Name);
        }

        [Fact]
        public void Customer_SetPhoneNumber_StoresPhoneNumberAsString()
        {
            var customer = new Customer();
            customer.PhoneNumber = "12345678";
            Assert.Equal("12345678", customer.PhoneNumber);
        }

        [Fact]
        public void Customer_SetEmail_StoresEmailAsString()
        {
            var customer = new Customer();
            customer.Email = "isabella@hotmail.com";
            Assert.Equal("isabella@hotmail.com", customer.Email);
        }
    }
}