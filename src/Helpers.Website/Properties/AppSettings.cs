using System;

namespace Helpers.Website
{
    public class AppSettings
    {
        public string Repository { get; set; }
        public string Source { get { return $"http://github.com/{Repository}"; } }
        public string Download { get { return $"http://github.com/{Repository}/zipball/master"; } }
        public int PageSize { get; set; }
    }
}
