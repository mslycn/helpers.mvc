using Helpers.Core.Extensions;
using Helpers.Core.Library;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Helpers.TagHelpers
{
    /// <summary>
    /// <see cref="ITagHelper"/>An implementation of a custom &lt;pager&gt; control.
    /// </summary>
    [TargetElement("pager")]
    public class PagerTagHelper : TagHelper
    {
        ///<exclude/>
        [HtmlAttributeNotBound, ViewContext]
        public ViewContext ViewContext { get; set; }
        ///<exclude/>
        [HtmlAttributeNotBound]
        protected IUrlHelper UrlHelper { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        public string AspAction { get; set; }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        public string AspController { get; set; }

        public string AspProtocol { get; set; }
        public string AspHost { get; set; }
        public string AspFragment { get; set; }

        /// <summary>
        /// Gets or sets the model expression.
        /// </summary>
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }
        private const string ForAttributeName = "asp-for";

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        [HtmlAttributeName(PageIndexAttributeName)]
        public int PageIndex { get; set; } = 0;
        private const string PageIndexAttributeName = "page-index";

        /// <summary>
        /// Gets or sets the number of rows shown on the page.
        /// </summary>
        [HtmlAttributeName(PageSizeAttributeName)]
        public int PageSize { get; set; } = PagerDefaults.PageSize;
        private const string PageSizeAttributeName = "page-size";

        /// <summary>
        /// Gets or sets the total number of records in the enumeration.
        /// </summary>
        [HtmlAttributeName(TotalAttributeName)]
        public int Total { get; set; } = 0;
        private const string TotalAttributeName = "total";

        ///<inheritDoc/>
        [HtmlAttributeName("class")]
        public string PagerClass { get; set; }
        ///<inheritDoc/>
        [HtmlAttributeName("links")]
        public int PagerLinks { get; set; } = PagerDefaults.Links;
        ///<inheritDoc/>
        [HtmlAttributeName("halign")]
        public HorizontalAlignment PagerHalign { get; set; } = PagerDefaults.Halign;
        ///<inheritDoc/>
        [HtmlAttributeName("show-status")]
        public bool PagerShowStatus { get; set; } = PagerDefaults.ShowStatus;
        ///<inheritDoc/>
        [HtmlAttributeName("show-sizes")]
        public bool PagerShowSizes { get; set; } = PagerDefaults.ShowSizes;
        ///<inheritDoc/>
        [HtmlAttributeName("status-format")]
        public string PagerStatusFormat { get; set; } = StringResources.PagerStatusFormat;
        ///<inheritDoc/>
        [HtmlAttributeName("sizes-format")]
        public string PagerSizesFormat { get; set; } = PagerDefaults.Sizes;
        ///<inheritDoc/>
        [HtmlAttributeName("prev-text")]
        public string PagerPrevText { get; set; } = StringResources.PagerPrevText;
        ///<inheritDoc/>
        [HtmlAttributeName("next-text")]
        public string PagerNextText { get; set; } = StringResources.PagerNextText;
        ///<inheritDoc/>
        [HtmlAttributeName("first-text")]
        public string PagerFirstText { get; set; } = StringResources.PagerFirstText;
        ///<inheritDoc/>
        [HtmlAttributeName("last-text")]
        public string PagerLastText { get; set; } = StringResources.PagerLastText;

        ///<exclude/>
        private const string RouteAttributePrefix = "asp-route-";
        ///<exclude/>
        private const string AjaxAttributePrefix = "data-ajax";

        ///<exclude/>
        private string[] PossiblePageIndexParameterNames = { "Page", "Current", "Index", "CurrentPage" };
        ///<exclude/>
        private string[] PossiblePageSizeParameterNames = { "PageSize", "Size" };
        ///<exclude/>
        private string[] PossibleTotalParameterNames = { "TotalCount", "Total", "Count", "TotalItemCount" };

        public PagerTagHelper(IUrlHelper urlHelper)
        {
            UrlHelper = urlHelper;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //has an action or controller been specified? if not, default
            if (string.IsNullOrEmpty(AspAction))
                AspAction = (string)ViewContext.RouteData.Values["action"];
            if (string.IsNullOrEmpty(AspController))
                AspController = (string)ViewContext.RouteData.Values["controller"];
            if (string.IsNullOrEmpty(AspController))
                throw new ArgumentException($"You must specify the '{nameof(AspController).SplitCamelCase('-').ToLower()}' attribute");

            //not specified any pager parameters
            if (!context.AllAttributes.ContainsName(PageIndexAttributeName) &&
                !context.AllAttributes.ContainsName(PageSizeAttributeName) &&
                !context.AllAttributes.ContainsName(TotalAttributeName))
            {
                //get the model otherwise use the view model
                ModelExplorer explorer = For?.ModelExplorer;
                if (explorer == null)
                    explorer = ViewContext.ViewData.ModelExplorer;

                //get the paging values from the model (support the popular pager paramter names)
                var index = explorer.GetExplorerForProperty(PossiblePageIndexParameterNames);
                var size = explorer.GetExplorerForProperty(PossiblePageSizeParameterNames);
                var total = explorer.GetExplorerForProperty(PossibleTotalParameterNames);

                if (index == null || size == null || total == null)
                    throw new ArgumentException($"A model MUST contain values for a page-index, page-size and total.");

                PageIndex = Convert.ToInt32(index.Model);
                PageSize = Convert.ToInt32(size.Model);
                Total = Convert.ToInt32(total.Model);
            }

            output.TagName = null;
            //if there are no rows then don't show
            if (PageSize != 0 && Total != 0)
                output.Content.SetContent(Create(output, PageIndex, Total, PageSize));

            await base.ProcessAsync(context, output);
        }

        private string Create(TagHelperOutput output, int pageIndex, int totalItems, int pageSize)
        {
            return new FluentTagBuilder()
                .StartTag("div", "row").Style("display: flex; align-items: center;")
                    .Action(tag =>
                    {
                        if (PagerHalign == HorizontalAlignment.Left)
                        {
                            tag.Append(CreatePager(output, pageIndex, totalItems, pageSize));
                            tag.Append(CreateStatus(output, pageIndex, totalItems, pageSize));
                        }
                        else
                        {
                            tag.Append(CreateStatus(output, pageIndex, totalItems, pageSize));
                            tag.Append(CreatePager(output, pageIndex, totalItems, pageSize));
                        }
                    })
                .EndTag();
        }

        private string CreateStatus(TagHelperOutput output, int pageIndex, int totalItems, int pageSize)
        {
            return new FluentTagBuilder()
                .StartTag("div", "col-md-6")
                    .Style(PagerHalign == HorizontalAlignment.Left ? "text-align: right;" : "text-align: left;")
                    .ActionIf(PagerShowStatus, tag =>
                    {
                        var from = ((pageIndex - 1) * pageSize) + 1;
                        var to = pageSize * pageIndex <= Total ? pageSize * pageIndex : Total;
                        var text = new FluentTagBuilder()
                            .StartTag("text").Style("display: inline-block;")
                                .Append(string.Format($"{PagerStatusFormat}&nbsp;", from, to, totalItems))
                            .EndTag();
                        tag.Append(text);
                    })
                    .ActionIf(PagerShowSizes, tag =>
                    {
                        tag.Append(CreateStatusList(output, pageIndex, totalItems, pageSize));
                    })
                .EndTag();
        }

        private string CreateStatusList(TagHelperOutput output, int pageIndex, int totalItems, int pageSize)
        {
            var routeValues = output.TrimPrefixedAttributes(RouteAttributePrefix);
            var ajaxValues = output.FindPrefixedAttributes(AjaxAttributePrefix);

            routeValues["page"] = pageIndex;
            string[] pageList = PagerSizesFormat.Split(',').Select(s => s.Trim()).ToArray();

            return new FluentTagBuilder()
                .StartTag("div", "dropdown").Style("display: inline-block;")
                    .StartTag("button", "btn btn-default dropdown-toggle").Attribute("data-toggle", "dropdown")
                        .Append($"{pageSize}&nbsp;")
                        .StartTag("span", "caret")
                        .EndTag()
                    .EndTag()
                    .StartTag("ul", "dropdown-menu")
                        .Action(menu =>
                        {
                            foreach (string item in pageList)
                            {
                                routeValues["pageSize"] = item;
                                var li = new FluentTagBuilder()
                                   .StartTag("li").Anchor(UrlHelper.Action(AspAction, AspController, routeValues), item, ajaxValues).EndTag();
                                menu.Append(li);
                            }
                        })
                    .EndTag()
                .EndTag()
                .StartTag("text").Style("display: inline-block;")
                    .Append($"&nbsp;{StringResources.PagerSizesText}")
                .EndTag();
        }

        private string CreatePager(TagHelperOutput output, int pageIndex, int totalItems, int pageSize)
        {
            if (totalItems <= 0)
                return string.Empty;

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var lastPageNumber = (int)Math.Ceiling((double)pageIndex / PagerLinks) * PagerLinks;
            var firstPageNumber = lastPageNumber - (PagerLinks - 1);
            var hasPreviousPage = pageIndex > 1;
            var hasNextPage = pageIndex < totalPages;
            if (lastPageNumber > totalPages)
                lastPageNumber = totalPages;

            var ulClass = PagerHalign == HorizontalAlignment.Right ? "pull-right" : string.Empty;

            return new FluentTagBuilder()
                .StartTag("div", "col-md-6")
                    .StartTag("ul", $"pagination {ulClass} {PagerClass}")
                        .Append(AddLink(output, 1, false, pageIndex == 1, PagerFirstText, StringResources.PagerFirstHint))
                        .Append(AddLink(output, pageIndex - 1, false, !hasPreviousPage, PagerPrevText, StringResources.PagerPrevHint))
                        .Action(tag =>
                        {
                            for (int i = firstPageNumber; i <= lastPageNumber; i++)
                                tag.Append(AddLink(output, i, i == pageIndex, false, i.ToString(), i.ToString()));
                        })
                        .Append(AddLink(output, pageIndex + 1, false, !hasNextPage, PagerNextText, StringResources.PagerNextHint))
                        .Append(AddLink(output, totalPages, false, pageIndex == totalPages, PagerLastText, StringResources.PagerLastHint))
                    .EndTag()
                .EndTag();
        }

        private string AddLink(TagHelperOutput output, int index, bool active, bool disabled, string linkText, string tooltip)
        {
            var routeValues = output.TrimPrefixedAttributes(RouteAttributePrefix);
            var ajaxValues = output.FindPrefixedAttributes(AjaxAttributePrefix);
            if (!disabled)
            {
                routeValues["page"] = index;
                if (PagerShowSizes)
                    routeValues["pageSize"] = PageSize;
            }

            return new FluentTagBuilder()
                .StartTag("li")
                    .Attribute("title", tooltip)
                    .ActionIf(active, tag => tag.Class("active"))
                    .ActionIf(disabled, tag => tag.CombineAttribute("class", "disabled"))
                    .StartTag("a")
                        .Attribute("title", tooltip)
                        .ActionIf(!disabled, tag => tag.Attribute("href", UrlHelper.Action(AspAction, AspController, routeValues, AspProtocol, AspHost, AspFragment)))
                        .Attributes(ajaxValues)
                        .Append(linkText)
                    .EndTag()
                .EndTag();
        }
    }
}
