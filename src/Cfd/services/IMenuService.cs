using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cfd.Models;

namespace Cfd.services
{
    public interface IMenuService
    {
        Task<string> GetMenuItembyId(int menuItemId);
        Task<MenuItem> GetMenuItemName(int menuItemId);
    }
}
