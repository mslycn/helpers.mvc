using System.Text.RegularExpressions;

namespace Helpers.Core.Extensions
{
    /// <exclude/>
    internal static partial class ExtensionMethods
    {
        /// <exclude/>
        public static string SplitCamelCase(this string str, char sep = ' ')
            => Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", $"$1{sep}$2"), @"(\p{Ll})(\P{Ll})", $"$1{sep}$2");
    }
}
