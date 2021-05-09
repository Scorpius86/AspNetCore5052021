using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCore5.Fundamentals.Web.Pages.People
{
    public class IndexModel : PageModel
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public void OnGet()
        {
            Title = "People - Index";
        }
    }
}
