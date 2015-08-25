using Helpers.Website.Infrastructure.Extensions;
using Helpers.Website.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using System.Linq;
using System.Threading.Tasks;

namespace Helpers.Website.Controllers
{
    public class BaseController : Controller
    {
        private readonly IOptions<AppSettings> _settings;

        public BaseController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        protected IActionResult GetView(int? page, int? pageSize = null)
        {
            var Page = (page != null && page >= 0 ? (int)page : 1);
            var PageSize = (pageSize != null && pageSize >= 1) ? (int)pageSize : _settings.Options.PageSize;

            var Model = SampleContext.People
                .Select(p => new BasicPersonView(p))
                .ToPagedList(Page, PageSize);

            if (Request.IsAjaxRequest())
                return PartialView("_PeopleAjaxTable", Model);
            else
                return View(Model);
        }

        protected async Task<IActionResult> GetViewAsync(int? page, int? pageSize = null)
            => await Task.FromResult(GetView(page, pageSize));
    }
}
