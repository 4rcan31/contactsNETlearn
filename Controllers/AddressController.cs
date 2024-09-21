using contactsNETlearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contactsNETlearn.Controllers
{
    [Route("Address")]
    public class AddressController : Controller
    {
        private readonly ApiCsTestContext _context;

        public AddressController(ApiCsTestContext context)
        {
            _context = context;
        }

        // Listar todas las direcciones
        [HttpGet]
        public IActionResult Index()
        {
            var addresses = _context.Addresses.Include(a => a.Contact).ToList();
            return RedirectToAction("Index", "Contact");
        }

        // Crear una nueva dirección
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }

        // Editar una dirección existente
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Address address)
        {
          

            if (ModelState.IsValid)
            {
                _context.Update(address);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }

        // Eliminar una dirección
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var address = _context.Addresses.Find(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
