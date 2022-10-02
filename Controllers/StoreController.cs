using Microsoft.AspNetCore.Mvc;
using Task_Rubikans.Data;
using Task_Rubikans.Models;
using Task_Rubikans.Repository;

namespace Task_Rubikans.Controllers
{
    public class StoreController : Controller
    {
        private readonly DataContext _contxt;
      

        public StoreController(DataContext contxt )
        {
            _contxt = contxt;
         
        }
        //Display SaleInvoice Table
        public IActionResult Index()
        {
            var saleInvoices = _contxt.SaleInvoices.ToList();
            return View(saleInvoices);
        }
        //Fill DropDownLists
        public IActionResult InfoAjax()
        {
            var items = _contxt.Items.ToList();
            var clients = _contxt.Clients.ToList();
            var inventories = _contxt.Inventories.ToList();
            return Json(new { inventories, items, clients });
        }
        //Display Create Page
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(SaleInvoice model)     
        {
            Client client=_contxt.Clients.FirstOrDefault( c=>c.Id== model.ClientId);
            model.ClientName = client.Name;
            foreach (var item in model.SaleInvoiceDetails)
                item.Total = item.Qty * item.Price;

            model.TotalQty = model.SaleInvoiceDetails.Sum(x => x.Qty);
            model.TotalAmount = model.SaleInvoiceDetails.Sum(x => x.Price);
            _contxt.SaleInvoices.Add(model);
            _contxt.SaveChanges();
            return Json(model.Id);
        }
    }
}
