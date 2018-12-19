using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using RaunstrupAuth.Controllers;
using RaunstrupAuth.Data;
using Xunit;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UnitTest
{
    public class UnitTest1
    {

        
        [Fact]
        public async Task Details_SkalIndeholde()
        {

            // Arrange
            var controller = new BynavnController(context: null);            
            // Act
            var result = await controller.Details(id: null);

            // Assert
            var redirectToActionResult =
                Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);


        }
        [Fact]
        public async Task Edit_SkalIndeholde()
        {
            var controller = new BynavnController(context: null);
            // Act
            var result = await controller.Edit(id: null);

            // Assert
            var redirectToActionResult =
                Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Create_SkalIndeholde()
        {
            var controller = new BynavnController(context: null);
            // Act
            var result = await controller.Edit(id: null);

            // Assert
            var redirectToActionResult =
                Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
        
    }
}
