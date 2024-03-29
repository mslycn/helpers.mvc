﻿using Helpers.Core.Extensions;
using Helpers.Core.Library;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpers.TagHelpers
{
    /// <summary>
    /// <see cref="ITagHelper"/>An implementation of a custom &lt;pager&gt; control.
    /// </summary>
    [TargetElement("pager")]
    public class PagerTagHelper : TagHelper, IPagerAttributes
    {
        /// <exclude/>
        [HtmlAttributeNotBound, ViewContext]
        public ViewContext ViewContext { get; set; }
        /// <exclude/>
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

        #region IPagerAttributes
        /// <inheritDoc/>
        [HtmlAttributeName("class")]
        public string PagerClass { get; set; } = PagerDefaults.Class;
        /// <inheritDoc/>
        [HtmlAttributeName("links")]
        public int PagerLinks { get; set; } = PagerDefaults.Links;
        /// <inheritDoc/>
        [HtmlAttributeName("halign")]
        public HorizontalAlignment PagerHalign { get; set; } = PagerDefaults.Halign;
        /// <inheritDoc/>
        [HtmlAttributeName("show-status")]
        public bool PagerShowStatus { get; set; } = PagerDefaults.ShowStatus;
        /// <inheritDoc/>
        [HtmlAttributeName("show-sizes")]
        public bool PagerShowSizes { get; set; } = PagerDefaults.ShowSizes;
        /// <inheritDoc/>
        [HtmlAttributeName("status-format")]
        public string PagerStatusFormat { get; set; } = StringResources.PagerStatusFormat;
        /// <inheritDoc/>
        [HtmlAttributeName("sizes-format")]
        public string PagerSizesFormat { get; set; } = PagerDefaults.Sizes;
        /// <inheritDoc/>
        [HtmlAttributeName("prev-text")]
        public string PagerPrevText { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("next-text")]
        public string PagerNextText { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("first-text")]
        public string PagerFirstText { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("last-text")]
        public string PagerLastText { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("hide-first-last")]
        public bool PagerHideFirstLast { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("hide-next-prev")]
        public bool PagerHideNextPrev { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("hide-page-skips")]
        public bool PagerHidePageSkips { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("first-icon")]
        public string PagerFirstIcon { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("prev-icon")]
        public string PagerPrevIcon { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("next-icon")]
        public string PagerNextIcon { get; set; }
        /// <inheritDoc/>
        [HtmlAttributeName("last-icon")]
        public string PagerLastIcon { get; set; }
        #endregion

        /// <exclude/>
        private const string RouteAttributePrefix = "asp-route-";
        /// <exclude/>
        private IDictionary<string, object> RouteValues;
        /// <exclude/>
        private const string AjaxAttributePrefix = "data-ajax";
        /// <exclude/>
        private IDictionary<string, object> AjaxValues;

        /// <exclude/>
        private string[] PossiblePageIndexParameterNames = { "Page", "Current", "Index", "CurrentPage" };
        /// <exclude/>
        private string[] PossiblePageSizeParameterNames = { "PageSize", "Size" };
        /// <exclude/>
        private string[] PossibleTotalParameterNames = { "TotalCount", "Total", "Count", "TotalItemCount" };

        public PagerTagHelper(IUrlHelper urlHelper)
        {
            UrlHelper = urlHelper;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            RouteValues = output.TrimPrefixedAttributes(RouteAttributePrefix);
            AjaxValues = output.FindPrefixedAttributes(AjaxAttributePrefix);

            ApplyActionAttributes();
            ApplyPaginationAttributes(context);
            ApplyIconTextAttributes();

            output.TagName = null;
            //if there are no rows then don't show
            if (PageSize != 0 && Total != 0)
                output.Content.SetContent(Create(PageIndex, Total, PageSize));

            await base.ProcessAsync(context, output);
        }

        private void ApplyActionAttributes()
        {
            //has an action or controller been specified? if not, default
            if (string.IsNullOrEmpty(AspAction))
                AspAction = (string)ViewContext.RouteData.Values["action"];
            if (string.IsNullOrEmpty(AspController))
                AspController = (string)ViewContext.RouteData.Values["controller"];
            if (string.IsNullOrEmpty(AspController))
                throw new ArgumentException($"You must specify the '{nameof(AspController).SplitCamelCase('-').ToLower()}' attribute");
        }

        private void ApplyPaginationAttributes(TagHelperContext context)
        {
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
        }

        private void ApplyIconTextAttributes()
        {
            if (string.IsNullOrEmpty(PagerFirstIcon) && string.IsNullOrEmpty(PagerFirstText))
                PagerFirstText = StringResources.PagerFirstText;
            if (string.IsNullOrEmpty(PagerFirstIcon) && string.IsNullOrEmpty(PagerPrevText))
                PagerPrevText = StringResources.PagerPrevText;
            if (string.IsNullOrEmpty(PagerFirstIcon) && string.IsNullOrEmpty(PagerNextText))
                PagerNextText = StringResources.PagerNextText;
            if (string.IsNullOrEmpty(PagerFirstIcon) && string.IsNullOrEmpty(PagerLastText))
                PagerLastText = StringResources.PagerLastText;
        }

        private string Create(int pageIndex, int totalItems, int pageSize)
        {
            return new FluentTagBuilder()
                .StartTag("div", "row").Style("display: flex; align-items: center;")
                    .Action(tag =>
                    {
                        if (PagerHalign == HorizontalAlignment.Left)
                        {
                            tag.Append(CreatePager(pageIndex, totalItems, pageSize));
                            tag.Append(CreateStatus(pageIndex, totalItems, pageSize));
                        }
                        else
                        {
                            tag.Append(CreateStatus(pageIndex, totalItems, pageSize));
                            tag.Append(CreatePager(pageIndex, totalItems, pageSize));
                        }
                    })
                .EndTag();
        }

        private string CreateStatus(int pageIndex, int totalItems, int pageSize)
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
                        tag.Append(CreateStatusList(pageIndex, totalItems, pageSize));
                    })
                .EndTag();
        }

        private string CreateStatusList(int pageIndex, int totalItems, int pageSize)
        {
            RouteValues["page"] = pageIndex;
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
                                RouteValues["pageSize"] = item;
                                var li = new FluentTagBuilder()
                                   .StartTag("li").Anchor(UrlHelper.Action(AspAction, AspController, RouteValues, AspProtocol, AspHost, AspFragment), item, AjaxValues).EndTag();
                                menu.Append(li);
                            }
                        })
                    .EndTag()
                .EndTag()
                .StartTag("text").Style("display: inline-block;")
                    .Append($"&nbsp;{StringResources.PagerSizesText}")
                .EndTag();
        }

        private string CreatePager(int pageIndex, int totalItems, int pageSize)
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
                    .StartTag("ul", $"{ulClass} {PagerClass}")
                        .AppendIf(!PagerHidePageSkips && !PagerHideFirstLast,
                            AddLink(1, false, pageIndex == 1, PagerFirstText, StringResources.PagerFirstHint, PagerFirstIcon, HorizontalAlignment.Left))
                        .AppendIf(!PagerHidePageSkips && !PagerHideNextPrev,
                            AddLink(pageIndex - 1, false, !hasPreviousPage, PagerPrevText, StringResources.PagerPrevHint, PagerPrevIcon, HorizontalAlignment.Left))
                        .Action(tag =>
                        {
                            for (int i = firstPageNumber; i <= lastPageNumber; i++)
                                tag.Append(AddLink(i, i == pageIndex, false, i.ToString(), i.ToString(), null, HorizontalAlignment.Left));
                        })
                        .AppendIf(!PagerHidePageSkips && !PagerHideNextPrev,
                                AddLink(pageIndex + 1, false, !hasNextPage, PagerNextText, StringResources.PagerNextHint, PagerNextIcon, HorizontalAlignment.Right))
                        .AppendIf(!PagerHidePageSkips && !PagerHideFirstLast,
                                AddLink(totalPages, false, pageIndex == totalPages, PagerLastText, StringResources.PagerLastHint, PagerLastIcon, HorizontalAlignment.Right))
                    .EndTag()
                .EndTag();
        }

        private string AddLink(int index, bool active, bool disabled, string linkText, string tooltip, string icon, HorizontalAlignment iconPosition)
        {
            if (!disabled)
            {
                RouteValues["page"] = index;
                if (PagerShowSizes)
                    RouteValues["pageSize"] = PageSize;
            }

            return new FluentTagBuilder()
                .StartTag("li")
                    .Attribute("title", tooltip)
                    .ActionIf(active, tag => tag.Class("active"))
                    .ActionIf(disabled, tag => tag.CombineAttribute("class", "disabled"))
                    .StartTag("a")
                        .Attribute("title", tooltip)
                        .ActionIf(!disabled, tag => tag.Attribute("href", UrlHelper.Action(AspAction, AspController, RouteValues, AspProtocol, AspHost, AspFragment)))
                        .Attributes(AjaxValues)
                        .Append(tag =>
                        {
                            if (!string.IsNullOrEmpty(icon))
                            {
                                return new FluentTagBuilder()
                                    .StartTag("span")
                                        .AppendIf(iconPosition == HorizontalAlignment.Left, new FluentTagBuilder()
                                            .StartTag("i").Attribute("class", icon).EndTag()
                                            .AppendIf(!string.IsNullOrEmpty(linkText), Const.NonBreakingSpace))
                                        .Append(linkText)
                                        .AppendIf(iconPosition == HorizontalAlignment.Right, new FluentTagBuilder()
                                            .AppendIf(!string.IsNullOrEmpty(linkText), Const.NonBreakingSpace)
                                            .StartTag("i").Attribute("class", icon).EndTag())
                                    .EndTag();
                            }
                            else
                                return new FluentTagBuilder().Append(linkText);
                        })
                    .EndTag()
                .EndTag();
        }
    }
}
