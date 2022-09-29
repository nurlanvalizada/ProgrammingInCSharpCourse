using System.IO;
using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Models;

namespace MovieWebApp.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var lastUpdated = new FileInfo(typeof(Startup).Assembly.Location).LastWriteTime;
        return View(new FooterViewModel
        {
            LastUpdatedTime = lastUpdated
        });
    }
}