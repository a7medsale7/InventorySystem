using System;
using System.IO;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.ReportAppServer.Controllers;
using CrystalDecisions.ReportAppServer.DataSetConversion;
using RASData = CrystalDecisions.ReportAppServer.DataDefModel;
using RASReport = CrystalDecisions.ReportAppServer.ReportDefModel;

namespace InventoryManagementSystem.Reports
{
    /// <summary>
    /// Inventory Crystal Report. Loads Reports\InventoryReport.rpt when present;
    /// otherwise builds a simple layout at runtime via In-Proc RAS and saves the .rpt.
    /// </summary>
    public class InventoryReport : CrystalDecisions.CrystalReports.Engine.ReportDocument
    {
        private static readonly string[] DisplayFields =
        {
            "ProductId", "Name", "Quantity", "Price",
            "SupplierName", "CategoryName", "TotalValue", "StockStatus"
        };

        public InventoryReport()
        {
            EnsureReportDefinition();
        }

        public void Bind(System.Data.DataTable products, int threshold)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            if (products.TableName != "Products")
                products.TableName = "Products";

            SetDataSource(products);

            try
            {
                SetParameterValue("Threshold", threshold);
            }
            catch (Exception)
            {
                // Parameter may be absent on a generated template.
            }
        }

        private void EnsureReportDefinition()
        {
            string rptPath = ResolveRptPath();
            if (File.Exists(rptPath))
            {
                Load(rptPath);
                return;
            }

            BuildAndSave(rptPath);
            Load(rptPath);
        }

        private static string ResolveRptPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidates =
            {
                Path.Combine(baseDir, "Reports", "InventoryReport.rpt"),
                Path.Combine(baseDir, @"..\..\Reports\InventoryReport.rpt"),
                Path.Combine(baseDir, @"..\..\..\Reports\InventoryReport.rpt"),
            };

            foreach (string c in candidates)
            {
                string full = Path.GetFullPath(c);
                if (File.Exists(full)) return full;
            }

            string projectReports = Path.GetFullPath(Path.Combine(baseDir, @"..\..\Reports"));
            if (!Directory.Exists(projectReports))
                projectReports = Path.Combine(baseDir, "Reports");
            Directory.CreateDirectory(projectReports);
            return Path.Combine(projectReports, "InventoryReport.rpt");
        }

        private void BuildAndSave(string rptPath)
        {
            var schema = new System.Data.DataTable("Products");
            schema.Columns.Add("ProductId", typeof(int));
            schema.Columns.Add("Name", typeof(string));
            schema.Columns.Add("Description", typeof(string));
            schema.Columns.Add("Quantity", typeof(int));
            schema.Columns.Add("Price", typeof(decimal));
            schema.Columns.Add("SupplierName", typeof(string));
            schema.Columns.Add("CategoryId", typeof(int));
            schema.Columns.Add("CategoryName", typeof(string));
            schema.Columns.Add("TotalValue", typeof(decimal));
            schema.Columns.Add("StockStatus", typeof(string));
            schema.Columns.Add("IsLowStock", typeof(bool));

            var ds = new System.Data.DataSet("InventoryDataSet");
            ds.Tables.Add(schema);

            ISCDReportClientDocument rcd = ReportClientDocument;
            rcd.New();

            RASData.ISCRDataSet rasDs = DataSetConverter.Convert(ds);
            rcd.DatabaseController.AddDataSource(rasDs);

            ISCRResultFieldController rfc = rcd.DataDefController.ResultFieldController;
            RASData.ISCRTable table = rcd.Database.Tables[0];

            foreach (string fieldName in DisplayFields)
            {
                int idx = table.DataFields.Find(
                    fieldName,
                    RASData.CrFieldDisplayNameTypeEnum.crFieldDisplayNameName,
                    RASData.CeLocale.ceLocaleUserDefault);

                if (idx >= 0)
                    rfc.Add(-1, table.DataFields[idx]);
            }

            try
            {
                RASReport.Section header = rcd.ReportDefinition.ReportHeaderArea.Sections[0];
                var textObj = new RASReport.TextObject();
                textObj.Name = "txtTitle";
                textObj.Height = 400;
                textObj.Width = 9000;
                textObj.Left = 200;
                textObj.Top = 100;
                rcd.ReportDefController.ReportObjectController.Add(textObj, header, -1);
            }
            catch
            {
                // Optional header decoration
            }

            Directory.CreateDirectory(Path.GetDirectoryName(rptPath) ?? ".");
            object pathObj = Path.GetDirectoryName(rptPath);
            rcd.SaveAs(Path.GetFileName(rptPath), ref pathObj, 0);
            Close();
        }
    }
}
