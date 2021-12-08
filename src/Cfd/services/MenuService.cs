using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cfd.Models;
using Microsoft.EntityFrameworkCore;

namespace Cfd.services
{
    public class MenuService : IMenuService
    {

        #region Property
        private readonly CfdContext _cfdContext;
        #endregion

        #region Constructor
        public MenuService(CfdContext cfdContext)
        {
            _cfdContext = cfdContext;
        }
        #endregion

        public async Task<string> GetMenuItembyId(int menuItemId)
        {
            var name = await _cfdContext.MenuItems.Where(c => c.Id == menuItemId).Select(d => d.Name).FirstOrDefaultAsync();
            return name;
        }

        public async Task<MenuItem> GetMenuItemName(int menuItemId)
        {
            var menuitem = await _cfdContext.MenuItems.FirstOrDefaultAsync(c => c.Id == menuItemId);
            return menuitem;
        }
    }
}
