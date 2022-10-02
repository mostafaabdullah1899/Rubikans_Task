using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Task_Rubikans.Data;
using Task_Rubikans.Reports;

namespace Task_Rubikans.Controllers
{
    public class PrintController : Controller
    {
        private readonly DataContext _contxt;
        public PrintController(DataContext contxt)
        {
            _contxt = contxt;
        }
        //Display SaleInvoice
        public IActionResult SaleInvoice(int id)
        {
            var saleInvoice = _contxt.SaleInvoices.Include(x => x.SaleInvoiceDetails)
                .FirstOrDefault(x => x.Id == id);

            SaleInvoice report = new();
            report.clientName.Text = saleInvoice.ClientName;
            var values = new string[4];

            report.table.BeginInit();
            for (int j = 0; j < saleInvoice.SaleInvoiceDetails.Count; j++)
            {
                XRTableRow xrRow = new();
                for (int i = 0; i < values.Length; i++)
                {
                    values[0] = saleInvoice.SaleInvoiceDetails[j].Total.ToString();
                    values[1] = saleInvoice.SaleInvoiceDetails[j].Qty.ToString();
                    values[2] = saleInvoice.SaleInvoiceDetails[j].Price.ToString();
                    values[3] = saleInvoice.SaleInvoiceDetails[j].ItemName;
                    XRTableCell xRCell = new()
                    {
                        BorderWidth = 1,
                        Text = values[i],
                        WidthF = 487.5f,
                        BorderColor = Color.Black,
                        BorderDashStyle = BorderDashStyle.Double,
                        Borders = BorderSide.All,
                        TextAlignment = TextAlignment.MiddleCenter,
                    };
                    xrRow.Cells.Add(xRCell);
                }
                report.table.Rows.Add(xrRow);
            }
            report.table.EndInit();
            ViewBag.Report = report;
            return View("ShowPreview");
        }
    }
}
