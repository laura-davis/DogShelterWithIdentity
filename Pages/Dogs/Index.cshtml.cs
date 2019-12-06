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
    public class IndexModel : PageModel
    {
        private readonly DogShelter.Data.ShelterContext _context;

        public IndexModel(DogShelter.Data.ShelterContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; }

        public async Task OnGetAsync()
        {
            Dog = await _context.Dog.ToListAsync();
        }
    }
}
