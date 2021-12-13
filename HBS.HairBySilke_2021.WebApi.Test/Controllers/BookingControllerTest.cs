using System.IO;
using System.Linq;
using System.Reflection;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HariBySilke_2021.WebApi.Controllers;
using HBS.HariBySilke_2021.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.WebApi.Test.Controllers
{
    public class BookingControllerTest
    {
        [Fact]
        public void BookingController_HasBookingService_IsOfTypeControllerBase()
        {
            var service = new Mock<IBookingService>();
            var controller = new BookingController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }

        [Fact]
        public void BookingController_WithNullBookingService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new BookingController(null));
        }

        [Fact]
        public void BookingController_UsesApiControllerAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(BookingController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }

        [Fact]
        public void BookingController_UsesRouteAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(BookingController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void BookingController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            //Arrange
            var typeInfo = typeof(BookingController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute")) as RouteAttribute;
            //Assert
            Assert.Equal("api/[controller]", attr.Template);
        }

        [Fact]
        public void BookingController_HasReadAllMethod_IsPublic()
        {
            var method = typeof(BookingController)
                .GetMethods().FirstOrDefault(m => "GetAllApp".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        [Fact]
        public void BookingController_HasReadAllMethod_ReturnsListOfAppointmentsInActionResult()
        {
            var method = typeof(BookingController)
                .GetMethods().FirstOrDefault(m => "GetAllApp".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<AppointmentDtos>).FullName, method.ReturnType.FullName);
        }

        [Fact]
        public void ReadAll_WithNoParams_HasGetHttpAttribute()
        {
            var methodInfo = typeof(BookingController)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "GetAllApp");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attr);
        }

        [Fact]
        public void ReadAll_CallsServicesGetBookings_Once()
        {
            //Arrange
            var mockService = new Mock<IBookingService>();
            var controller = new BookingController(mockService.Object);
            //Act
            controller.GetAllApp();
            //Assert
            mockService.Verify(s => s.GetAllApp(), Times.Once);
        }
    }
}