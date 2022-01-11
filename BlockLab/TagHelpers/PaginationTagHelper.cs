namespace BlockLab.TagHelpers;

/// <summary> Таг хелпер пагинации </summary>
public class PaginationTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;

    public PagiWebModel PageModel { get; set; }
    public string Action { get; set; }
    [ViewContext, HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }
    [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
    public Dictionary<string, object> PageUrlValues { get; set; } = new();

    public PaginationTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        output.TagName = "div";

        var tag = new TagBuilder("ul");
        tag.AddCssClass("pagination");

        var currentItem = CreateTag(PageModel.Page, urlHelper);

        if (PageModel.HasPreviousPage)
        {
            var prevItem = CreatePreviousTag(PageModel.Page - 1, urlHelper);
            tag.InnerHtml.AppendHtml(prevItem);
        }
        if (PageModel.HasFirstPage)
        {
            var firstItem = CreateTag(1, urlHelper);
            tag.InnerHtml.AppendHtml(firstItem);
        }
        if (PageModel.HasMorePrevPage)
        {
            var emp1 = CreateEmptyTag();
            tag.InnerHtml.AppendHtml(emp1);
        }
        if (PageModel.HasPrevPreviousPage)
        {
            var prevPrevItem = CreateTag(PageModel.Page - 2, urlHelper);
            tag.InnerHtml.AppendHtml(prevPrevItem);
        }
        if (PageModel.HasPreviousPage)
        {
            var prevItem = CreateTag(PageModel.Page - 1, urlHelper);
            tag.InnerHtml.AppendHtml(prevItem);
        }
        tag.InnerHtml.AppendHtml(currentItem);
        if (PageModel.HasNextPage)
        {
            var nextItem = CreateTag(PageModel.Page + 1, urlHelper);
            tag.InnerHtml.AppendHtml(nextItem);
        }
        if (PageModel.HasNextNextPage)
        {
            var nextNextItem = CreateTag(PageModel.Page + 2, urlHelper);
            tag.InnerHtml.AppendHtml(nextNextItem);
        }
        if (PageModel.HasMoreLastPage)
        {
            var emp2 = CreateEmptyTag();
            tag.InnerHtml.AppendHtml(emp2);
        }
        if (PageModel.HasLastPage)
        {
            var lastItem = CreateTag(PageModel.CountPages, urlHelper);
            tag.InnerHtml.AppendHtml(lastItem);
        }
        if (PageModel.HasNextPage)
        {
            var nextItem = CreateNextTag(PageModel.Page + 1, urlHelper);
            tag.InnerHtml.AppendHtml(nextItem);
        }

        output.Content.AppendHtml(tag);
    }

    TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
    {
        var item = new TagBuilder("li");
        var link = new TagBuilder("a");
        if (pageNumber == PageModel.Page)
        {
            item.AddCssClass("active");
        }
        else
        {
            PageUrlValues["page"] = pageNumber;
            link.Attributes["href"] = urlHelper.Action(Action, PageUrlValues);
        }

        foreach (var (key, value) in PageUrlValues.Where(v => v.Value is not null))
            link.MergeAttribute($"data-{key}", value.ToString());

        item.AddCssClass("page-item");
        link.AddCssClass("page-link");
        if (pageNumber != PageModel.Page)
        {
            link.AddCssClass("text-dark");
        }
        link.InnerHtml.Append(pageNumber.ToString());
        item.InnerHtml.AppendHtml(link);
        return item;
    }
    TagBuilder CreatePreviousTag(int pageNumber, IUrlHelper urlHelper)
    {
        var item = new TagBuilder("li");
        var link = new TagBuilder("a");
        PageUrlValues["page"] = pageNumber;
        link.Attributes["href"] = urlHelper.Action(Action, PageUrlValues);

        foreach (var (key, value) in PageUrlValues.Where(v => v.Value is not null))
            link.MergeAttribute($"data-{key}", value.ToString());

        item.AddCssClass("page-item");
        link.AddCssClass("page-link");
        link.AddCssClass("text-dark");
        var icon = new TagBuilder("i");
        icon.AddCssClass("glyphicon");
        icon.AddCssClass("glyphicon-chevron-left");
        link.InnerHtml.AppendHtml(icon);
        link.InnerHtml.Append(" Назад");
        item.InnerHtml.AppendHtml(link);
        return item;
    }
    TagBuilder CreateNextTag(int pageNumber, IUrlHelper urlHelper)
    {
        var item = new TagBuilder("li");
        var link = new TagBuilder("a");
        PageUrlValues["page"] = pageNumber;
        link.Attributes["href"] = urlHelper.Action(Action, PageUrlValues);

        foreach (var (key, value) in PageUrlValues.Where(v => v.Value is not null))
            link.MergeAttribute($"data-{key}", value.ToString());

        item.AddCssClass("page-item");
        link.AddCssClass("page-link");
        link.AddCssClass("text-dark");
        link.InnerHtml.Append("Вперед ");
        var icon = new TagBuilder("i");
        icon.AddCssClass("glyphicon");
        icon.AddCssClass("glyphicon-chevron-right");
        link.InnerHtml.AppendHtml(icon);
        item.InnerHtml.AppendHtml(link);
        return item;
    }
    TagBuilder CreateEmptyTag()
    {
        var item = new TagBuilder("li");
        item.AddCssClass("page-item");
        item.AddCssClass("p-1");
        item.AddCssClass("bg-secondary");
        item.AddCssClass("bg-opacity-50");
        return item;
    }
}

