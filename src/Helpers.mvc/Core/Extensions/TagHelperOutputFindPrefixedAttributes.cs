using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers.Core.Extensions
{
    /// <exclude/>
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Returns all attributes from <paramref name="tagHelperOutput"/>'s.
        /// </summary>
        public static IDictionary<string, object> FindPrefixedAttributes(this TagHelperOutput @this, string prefix)
            => @this.Attributes
                .Where(attribute => attribute.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(d => d.Name, d => d.Value);
    }
}
