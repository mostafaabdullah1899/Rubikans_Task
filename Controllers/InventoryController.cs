using Microsoft.AspNetCore.Mvc;
using Task_Rubikans.Data;
using Task_Rubikans.Models;
using Task_Rubikans.Repository;
using Task_Rubikans.ViewModel;

namespace Task_Rubikans.Controllers
{
    public class InventoryController : Controller
    {
        IInventoryRepository inventortRepository;
        IClientRepository clienRepo;
        private readonly DataContext _contxt;
        public InventoryController(IInventoryRepository _inventortRepository, IClientRepository _clienRepo, DataContext contxt)
        {
            inventortRepository = _inventortRepository;
            clienRepo = _clienRepo;
            _contxt = contxt;
        }

        public IActionResult Index()
        {

            return View(inventortRepository.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(inventortRepository.GetById(id));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Inventory newinventorty)
        {
            if (ModelState.IsValid)
            {
                inventortRepository.Add(newinventorty);
                return RedirectToAction("Index");
            }
            return View(newinventorty);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(inventortRepository.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Inventory newinventorty)
        {
            if (ModelState.IsValid)
            {
                inventortRepository.Update(id, newinventorty);
                return RedirectToAction("Index");
            }
            return View(newinventorty);
        }

        public IActionResult Delete(int id)
        {
            inventortRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetItems(int invent)
        {
            return Json(_contxt.Items.Where(i => i.InventoryId == invent).ToList());
        }
    }
}
