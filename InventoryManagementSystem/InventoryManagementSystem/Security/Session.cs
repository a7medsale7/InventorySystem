using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Security
{
    public static class Session
    {
        public static User CurrentUser { get; set; }

        public static bool IsAdmin
        {
            get { return CurrentUser != null && CurrentUser.Role == Role.Admin; }
        }

        // بنناديها قبل أي عملية تعديل. حماية حتى لو الزرار اتخفى غلط.
        public static void RequireAdmin()
        {
            if (!IsAdmin)
                throw new UnauthorizedAccessException("This action requires Admin role.");
        }
    }
}
