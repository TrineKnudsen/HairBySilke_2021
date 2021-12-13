using System.IO;
using System.Linq;
using System.Reflection;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Security.IServices;
using HBS.HariBySilke_2021.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.WebApi.Test.Controllers
{
    public class AuthControllerTest
    {
        [Fact]
        public void AuthController_HasSecurityService_IsOfTypeControllerBase()
        {
            var service = new Mock<ISecurityService>();
            var controller = new AuthController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }

        [Fact]
        public void AuthController_WithNullSecurityService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new AuthController(null));
        }

        [Fact]
        public void AuthController_UsesApiControllerAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(AuthController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }

        [Fact]
        public void AuthController_UsesRouteAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(AuthController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void AuthController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            //Arrange
            var typeInfo = typeof(AuthController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute")) as RouteAttribute;
            //Assert
            Assert.Equal("api/[controller]", attr.Template);
        }

        [Fact]
        public void HasLoginMethod_IsPublic()
        {
            var method = typeof(AuthController)
                .GetMethods().FirstOrDefault(m => "Login".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
    }
}