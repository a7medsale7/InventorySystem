using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public static class AppSettings
    {
        public static int LowStockThreshold
        {
            get
            {
                int value;
                return int.TryParse(ConfigurationManager.AppSettings["LowStockThreshold"], out value)
                    ? value : 10;
            }
        }
    }
}
