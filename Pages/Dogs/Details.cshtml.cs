using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogShelter.Data;
using DogShelter.Models;

namespace DogShelter.Pages.Dogs
{
    public class DetailsModel : PageModel
    {
        private readonly DogShelter.Data.ShelterContext _context;

        public DetailsModel(DogShelter.Data.ShelterContext context)
        {
            _context = context;
        }

        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog.FirstOrDefaultAsync(m => m.ID == id);

            if (Dog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
