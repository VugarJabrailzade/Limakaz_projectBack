using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.ViewModels.Contact;
using Limakaz.ViewModels.Officies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Admin
{
    [Route("admin/contact-details")]
    public class ContactController : Controller
    {
        public readonly LimakDbContext _limakDbContext;
        public readonly ILogger<ContactController> _logger;

        public ContactController(LimakDbContext limakDbContext, ILogger<ContactController> logger)
        {
            _limakDbContext = limakDbContext;
            _logger = logger;
        }

        [HttpGet("list", Name ="contact-details")]
        public IActionResult Contact()
        {
            var details = _limakDbContext.Contacts.ToList();

            return View("Views/Admin/Contact/Contact.cshtml", details);
        }

        [HttpGet("add", Name ="add-contact")]
        public IActionResult Add()
        {

            return View("Views/Admin/Contact/AddContact.cshtml");
        }

        [HttpPost("add", Name ="add-contact-post")]
        public IActionResult Add(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if (model == null)
            {
                ModelState.AddModelError("Name", "Can't be null");
                return BadRequest(new { message = "Can't be null" });
            }

            var existOffice = _limakDbContext.Contacts.FirstOrDefault(x => x.Id == model.Id);
            if (existOffice != null)
            {
                return BadRequest();

            }

            var contactAdd = new Contact
            {
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            _limakDbContext.Contacts.Add(contactAdd);
            _limakDbContext.SaveChanges();


            return RedirectToAction("Contact");
        }


        [HttpGet("update", Name ="contact-update")]
        public async Task<IActionResult> Update([FromQuery] int id)
        {

            var contact = await _limakDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (contact == null) return BadRequest(ModelState);

            var contactModel = new ContactRequestViewModel
            {
                Id = contact.Id,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email
            };

            return View("Views/Admin/Contact/UpdateContact.cshtml", contactModel);
        }

        [HttpPost("update", Name = "contact-update-post")]
        public async Task<IActionResult> Update([FromQuery] int id, ContactRequestViewModel model)
        {

            if (!ModelState.IsValid) { return BadRequest(); }


            var contactModel = new Contact
            {
                Id = model.Id,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            _limakDbContext.Contacts.Update(contactModel);
            _limakDbContext.SaveChanges();

            return RedirectToAction("Contact");
        }
    }
}
