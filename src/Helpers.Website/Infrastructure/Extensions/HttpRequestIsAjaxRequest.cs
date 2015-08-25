using Microsoft.AspNet.Http;

namespace Helpers.Website.Infrastructure.Extensions
{
    /// <exclude/>
    public static partial class ExtensionMethods
    {
        /// <exclude/>
        public static bool IsAjaxRequest(this HttpRequest @this)
            => @this?.Headers?["X-Requested-With"] == "XMLHttpRequest";
    }
}
