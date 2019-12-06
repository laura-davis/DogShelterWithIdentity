using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogShelter.Data;
using DogShelter.Models;

namespace DogShelter.Pages.Dogs
{
    public class EditModel : PageModel
    {
        private readonly DogShelter.Data.ShelterContext _context;

        public EditModel(DogShelter.Data.ShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dogs.FirstOrDefaultAsync(m => m.ID == id);

            if (Dog == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var dogToUpdate = await _context.Dogs.FindAsync(id);

            if (dogToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Dog>(
                dogToUpdate,
                "dog",
                d => d.Name, d => d.Breed, d=> d.Sex, d => d.Summary, d => d.ImageUrl, d => d.Adoptions))
            
                
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(Dog.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.ID == id);
        }
    }
}