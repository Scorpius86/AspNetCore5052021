using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCore5.Fundamentals.Web.Pages.People
{
    public class EditModel : PageModel
    {
        public string Tilte { get; set; }
        public void OnGet()
        {
            Tilte = "People - Edit";
        }
        
    }
}
