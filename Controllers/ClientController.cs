using Microsoft.AspNetCore.Mvc;
using Task_Rubikans.Models;
using Task_Rubikans.Repository;

namespace Task_Rubikans.Controllers
{
    public class ClientController : Controller
    {
        IClientRepository clientRepository;
        public ClientController(IClientRepository _clientRepository)
        {
            clientRepository= _clientRepository;
        }
        public IActionResult Index()
        {
            
            return View(clientRepository.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(clientRepository.GetById(id));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Client newClient)
        {
            if(ModelState.IsValid)
            {
                clientRepository.Add(newClient);
                return RedirectToAction("Index");
            }
            return View(newClient);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
          return View(clientRepository.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,Client newClient)
        {
            if (ModelState.IsValid)
            {
                clientRepository.Update(id, newClient);
                return RedirectToAction("Index");
            }
            return View(newClient);
        }
        
        public IActionResult Delete(int id)
        {
            clientRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
