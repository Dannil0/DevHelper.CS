using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevHelper.Data.Models;

namespace DevHelper.Razor.Pages.PgProblema
{
    public class DetailsModel : PageModel
    {
        private readonly DevHelper.Data.Models.DBdevhelperContext _context;

        public DetailsModel(DevHelper.Data.Models.DBdevhelperContext context)
        {
            _context = context;
        }

        public Problema Problema { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problema = await _context.Problemas.FirstOrDefaultAsync(m => m.Id == id);
            if (problema == null)
            {
                return NotFound();
            }
            else
            {
                Problema = problema;
            }
            return Page();
        }
    }
}
