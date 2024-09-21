using contactsNETlearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contactsNETlearn.Controllers
{
    [Route("Phone")]
    public class PhoneController : Controller
    {
        private readonly ApiCsTestContext _context;

        public PhoneController(ApiCsTestContext context)
        {
            _context = context;
        }

        // Listar todos los teléfonos
        [HttpGet]
        public IActionResult Index()
        {
            var phones = _context.Phones.Include(p => p.Contact).ToList();
            return RedirectToAction("Index", "Contact");
        }

        // Crear un nuevo teléfono
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Phones.Add(phone);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }

        // Editar un teléfono existente
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Update(phone);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }

        // Eliminar un teléfono
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var phone = _context.Phones.Find(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
