using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contacts.Data;
using Contacts.Models;
using Contacts.ViewModels;

namespace Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
              return _context.Contacts != null ? 
                          View(await _context.Contacts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Contacts'  is null.");
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/CreateOrEdit
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id=0)
        {
            if(id==0)
                return View(new Contact());
            else
            {
                var contact = await _context.Contacts.FindAsync(id);
                if (contact == null)
                {
                    return NotFound();
                }
                return View(contact);
            }
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,MobilePhone,JobId,BirthDate")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(contact);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(contact);
        //}

        // GET: Contacts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Contacts == null)
        //    {
        //        return NotFound();
        //    }

        //    var contact = await _context.Contacts.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(contact);
        //}

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id, [Bind("Id,Name,MobilePhone,BirthDate")] ViewContact contact)
        {
            if (ModelState.IsValid)
            {
                var domainEntity = contact.ToContact();
                if (id == 0)
                {
                    _context.Contacts.Add(domainEntity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(domainEntity);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ContactExists(domainEntity.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Contacts.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", contact) });
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
          return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
