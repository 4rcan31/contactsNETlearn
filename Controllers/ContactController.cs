using contactsNETlearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contactsNETlearn.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly ApiCsTestContext _context;

        public ContactController(ApiCsTestContext context)
        {
            _context = context;
        }

        // Leer (Listar todos los contactos)
        [HttpGet]
        public IActionResult Index()
        {
            var contacts = _context.Contacts
                .Include(c => c.Addresses)
                .Include(c => c.Emails)
                .Include(c => c.Phones)
                .ToList();

            return View(contacts);
        }

        [HttpPost("CreateContact")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Contact contact)
        {
            if (id != contact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Contact");
        }

        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
