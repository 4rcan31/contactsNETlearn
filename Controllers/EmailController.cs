using contactsNETlearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contactsNETlearn.Controllers
{
    [Route("Email")]
    public class EmailController : Controller
    {
        private readonly ApiCsTestContext _context;

        public EmailController(ApiCsTestContext context)
        {
            _context = context;
        }

        // Listar todos los correos electrónicos
        [HttpGet]
        public IActionResult Index()
        {
            var emails = _context.Emails.Include(e => e.Contact).ToList();
            return RedirectToAction("Index", "Contact");
        }

        // Crear un nuevo correo electrónico
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Emails.Add(email);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }

        // Editar un correo electrónico existente
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Update(email);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }

        // Eliminar un correo electrónico
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var email = _context.Emails.Find(id);
            if (email != null)
            {
                _context.Emails.Remove(email);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
