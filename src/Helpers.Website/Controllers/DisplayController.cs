using Helpers.Website.Models;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace TagHelpers.Website.Controllers
{
    public class DisplayController : Controller
    {
        public IActionResult Index()
            => View(SampleContext.People.Select(p => new BasicPersonView(p)).First());

        public IActionResult Basic()
            => View(SampleContext.People.Select(p => new BasicPersonView(p)).First());
    }
}
