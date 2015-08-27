using Microsoft.AspNet.Mvc.ModelBinding;

namespace Helpers.Core.Extensions
{
    internal static partial class ExtensionMethods
    {
        public static ModelExplorer GetExplorerForProperty(this ModelExplorer @this, string[] properties)
        {
            foreach(var property in properties)
            {
                var propertyExplorer = @this.GetExplorerForProperty(property);
                if (propertyExplorer != null)
                    return propertyExplorer;
            }
            return null;
        }
    }
}
