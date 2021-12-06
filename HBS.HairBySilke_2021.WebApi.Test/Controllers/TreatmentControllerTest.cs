using System.IO;
using System.Linq;
using System.Reflection;
using HBS.Domain.Services;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HariBySilke_2021.WebApi.Controllers;
using HBS.HariBySilke_2021.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.WebApi.Test.Controllers
{
    public class TreatmentControllerTest
    {
        [Fact]
        public void TreatmentController_HasTreatmentsService_IsOfTypeControllerBase()
        {
            var service = new Mock<ITreatmentsService>();
            var controller = new TreatmentController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }

        [Fact]
        public void TreatmentsController_WithNullTreatmentsService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new TreatmentController(null));
        }

        [Fact]
        public void TreatmentController_UsesApiControllerAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(TreatmentController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }

        [Fact]
        public void TreatmentController_UsesRouteAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(TreatmentController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void TreatmentController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            //Arrange
            var typeInfo = typeof(TreatmentController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute")) as RouteAttribute;
            //Assert
            Assert.Equal("api/[controller]", attr.Template);
        }

        [Fact]
        public void TreatmentController_HasReadAllMethod_IsPublic()
        {
            var method = typeof(TreatmentController)
                .GetMethods().FirstOrDefault(m => "ReadAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        [Fact]
        public void TreatmentController_HasReadAllMethod_ReturnsListOfProductsInActionResult()
        {
            var method = typeof(TreatmentController)
                .GetMethods().FirstOrDefault(m => "ReadAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<TreatmentDto>).FullName, method.ReturnType.FullName);
        }

        [Fact]
        public void ReadAll_WithNoParams_HasGetHttpAttribute()
        {
            var methodInfo = typeof(TreatmentController)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "ReadAll");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attr);
        }

        [Fact]
        public void ReadAll_CallsServicesGetTreatments_Once()
        {
            //Arrange
            var mockService = new Mock<ITreatmentsService>();
            var controller = new TreatmentController(mockService.Object);
            //Act
            controller.ReadAll();
            //Assert
            mockService.Verify(s => s.GetAllTreatments(), Times.Once);
        }
    }
}