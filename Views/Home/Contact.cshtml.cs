using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace Zurex.Views.Home
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
        }
    }
}
