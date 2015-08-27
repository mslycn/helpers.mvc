
namespace Helpers.TagHelpers
{
    /// <summary>
    /// Attributes available to the pager.
    /// </summary>
    internal interface IPagerAttributes
    {
        /// <summary>
        /// Class attribute set against the pager.
        /// </summary>
        string PagerClass { get; set; }
        /// <summary>
        /// The maximum number of page links to be shown.
        /// </summary>
        int PagerLinks { get; set; }
        /// <summary>
        /// The pagers horizontal alignment.
        /// </summary>
        HorizontalAlignment PagerHalign { get; set; }
        /// <summary>
        /// Whether to show the current page status message.
        /// </summary>
        bool PagerShowStatus { get; set; }
        /// <summary>
        /// Whether to display the page sizes that can be changed by the user.
        /// </summary>
        bool PagerShowSizes { get; set; }
        /// <summary>
        /// The message showing the status of the page and records.
        /// </summary>
        string PagerStatusFormat { get; set; }
        /// <summary>
        /// The available page sizes that can be selected.
        /// </summary>
        string PagerSizesFormat { get; set; }
        /// <summary>
        /// Text for the previous button.
        /// </summary>
        string PagerPrevText { get; set; }
        /// <summary>
        /// Text for the next button.
        /// </summary>
        string PagerNextText { get; set; }
        /// <summary>
        /// Text for the first button.
        /// </summary>
        string PagerFirstText { get; set; }
        /// <summary>
        /// Text for the last button.
        /// </summary>
        string PagerLastText { get; set; }
        /// <summary>
        /// Visibility of the first and last buttons
        /// </summary>
        bool PagerHideFirstLast { get; set; }
        /// <summary>
        /// Visibility of the next and previous buttons
        /// </summary>
        bool PagerHideNextPrev { get; set; }
        /// <summary>
        /// Visibility of the skip buttons
        /// </summary>
        bool PagerHidePageSkips { get; set; }
    }
}
