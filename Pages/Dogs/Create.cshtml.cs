using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogShelter.Data;
using DogShelter.Models;

namespace DogShelter.Pages.Dogs
{
    public class CreateModel : PageModel
    {
        private readonly DogShelter.Data.ShelterContext _context;

        public CreateModel(DogShelter.Data.ShelterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Dog Dog { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyDog = new Dog();
            if (await TryUpdateModelAsync<Dog>(emptyDog, "dog",
                d => d.Name, d => d.Breed, d=> d.Sex, d => d.Summary, d => d.ImageUrl, d => d.Adoptions))

                if (!ModelState.IsValid)
                {
                    return Page();
                }

            _context.Dogs.Add(emptyDog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}