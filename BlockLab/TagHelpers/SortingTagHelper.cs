namespace BlockLab.TagHelpers;

/// <summary> Таг хелпер сортировки </summary>
public class SortingTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;

    public ResearchSortState Property { get; set; }
    public ResearchSortState Current { get; set; }
    public string Action { get; set; }
    public bool Up { get; set; }

    [ViewContext, HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }

    [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
    public Dictionary<string, object> PageUrlValues { get; set; } = new();

    public SortingTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        output.TagName = "a";

        PageUrlValues["Order"] = Property;
        var url = urlHelper.Action(Action, PageUrlValues);

        output.Attributes.SetAttribute("href", url);
        output.Attributes.Add("class", "btn btn-sm btn-success");

        if (Current == Property)
        {
            var tag = new TagBuilder("i");
            tag.AddCssClass("fa");
            if (Up)
                tag.AddCssClass("fa-angle-up");
            else
                tag.AddCssClass("fa-angle-down");

            output.PostContent.AppendHtml(tag);
        }
    }
}

