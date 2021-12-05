using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cfd.Models;
using Cfd.services;

namespace Cfd.Controllers
{
    public class TestController : ControllerBase
    {
        #region Property
        private readonly IMenuService _menuService;
        #endregion

        #region Constructor
        public TestController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        #endregion

        [HttpGet(nameof(GetMenuItembyId))]
        public async Task<string> GetMenuItembyId(int menuItemId)
        {
            var result = await _menuService.GetMenuItembyId(menuItemId);
            return result;
        }

        [HttpGet(nameof(GetMenuItemName))]
        public async Task<MenuItem> GetMenuItemName(int menuItemId)
        {
            var result = await _menuService.GetMenuItemName(menuItemId);
            return result;
        }
    }
}
