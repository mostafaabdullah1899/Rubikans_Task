using Microsoft.AspNetCore.Mvc;
using Task_Rubikans.Models;
using Task_Rubikans.Repository;

namespace Task_Rubikans.Controllers
{
    public class ItemController : Controller
    {
        IItemRepository itemRepository;
        IInventoryRepository inventoryRepo;
        public ItemController(IItemRepository _itemRepository , IInventoryRepository _inventoryRepo)
        {
            itemRepository = _itemRepository;
            inventoryRepo= _inventoryRepo;
        }
        public IActionResult Index()
        {

            return View(itemRepository.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(itemRepository.GetById(id));
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Inventory"] = inventoryRepo.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item newitem)
        {
            if (ModelState.IsValid)
            {
                itemRepository.Add(newitem);
                return RedirectToAction(nameof(Index));
            }
            return View(newitem);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewData["Inventory"] = inventoryRepo.GetAll();
            return View(itemRepository.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Item newitem)
        {
            if (ModelState.IsValid)
            {
                itemRepository.Update(id, newitem);
                return RedirectToAction("Invoice" ,"Inventory");
            }
            ViewData["Inventory"] = inventoryRepo.GetAll();
            return View(newitem);
        }

        public IActionResult Delete(int id)
        {
            itemRepository.Delete(id);
            return RedirectToAction("Invoice" ,"Inventory");
        }
    }
}
