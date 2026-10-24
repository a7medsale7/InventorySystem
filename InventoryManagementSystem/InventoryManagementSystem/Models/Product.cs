using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SupplierName { get; set; }
        public int? CategoryId { get; set; }   // int? يعني ممكن تكون null

        // نص مختصر بنخزنه في AuditLogs (القيم القديمة/الجديدة)
        public string ToAuditString()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "Name={0}; Description={1}; Quantity={2}; Price={3:0.00}; Supplier={4}; CategoryId={5}",
                Name, Description, Quantity, Price, SupplierName, CategoryId);
        }
    }
}
