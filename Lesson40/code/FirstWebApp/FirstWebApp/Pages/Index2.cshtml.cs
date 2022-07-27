using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FirstWebApp.Pages
{
    public class Index2Model : PageModel
    {
        public string Message { get; private set; }

        public async Task OnGetAsync()
        {
            Message = DateTime.Now.ToString();
        }
    }
}
