using DogShelter.Data;
using DogShelter.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Data;

namespace DogShelter.Pages.Dogs
{
    public class IndexModel : PageModel
    {
        private readonly ShelterContext _context;

        public IndexModel(ShelterContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Dog> Dogs { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Dog> dogsIq = from s in _context.Dogs
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                dogsIq = dogsIq.Where(d => d.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    dogsIq = dogsIq.OrderByDescending(d => d.Name);
                    break;
                case "Date":
                    dogsIq = dogsIq.OrderBy(d => d.Dob);
                    break;
                case "date_desc":
                    dogsIq = dogsIq.OrderByDescending(d => d.Dob);
                    break;
                default:
                    dogsIq = dogsIq.OrderBy(d => d.Name);
                    break;
            }

            int pageSize = 3;
            Dogs = await PaginatedList<Dog>.CreateAsync(
                dogsIq.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}