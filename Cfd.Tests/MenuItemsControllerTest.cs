using System;
using Xunit;
using Moq;
using Cfd.Controllers;
using Cfd.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using Cfd.services;



namespace Cfd.Tests
{
    public class MenuItemsControllerTest
    {
        #region Property
        public Mock<IMenuService> mock = new Mock<IMenuService>();
        #endregion

        [Fact]
        public async void GetMenuItembyId()
        {
            mock.Setup(p => p.GetMenuItembyId(1)).ReturnsAsync("Water");
            TestController menuItem = new TestController(mock.Object);
            string result = await menuItem.GetMenuItembyId(1);
            Assert.Equal("Water", result);
        }

        [Fact]
        public async void GetMenuItemName()
        {
            var menuItem = new MenuItem()
            {
                Id = 1,
                Name = "Water",
                ImageId = 1,
                Price = 1.99,
                Description = "Fresh from the tap"
            };

            mock.Setup(p => p.GetMenuItemName(menuItem.Id)).ReturnsAsync(menuItem);
            TestController menuitem = new TestController(mock.Object);
            var result = await menuitem.GetMenuItemName(menuItem.Id);
            Assert.True(menuItem.Id.Equals(1));
        }
    }
}


