using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using System.Threading.Tasks;

namespace Helpers.Website.Controllers
{
    public class PagerController : BaseController
    {
        public PagerController(IOptions<AppSettings> settings)
            : base(settings) { }

        public IActionResult Index(int page, int pageSize)
            => GetView(page, pageSize);

        public IActionResult Basic(int page)
            => GetView(page);

        public IActionResult Config(int page)
            => GetView(page);

        public async Task<IActionResult> Ajax(int page, int pageSize)
            => await GetViewAsync(page, pageSize);
    }
}
