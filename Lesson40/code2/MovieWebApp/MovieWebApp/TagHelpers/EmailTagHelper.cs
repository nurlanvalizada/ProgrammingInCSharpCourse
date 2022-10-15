using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MovieWebApp.TagHelpers;

public class EmailTagHelper : TagHelper
{
    private const string DomainName = "test.com";
    
    [HtmlAttributeName("recipient")]
    public string MailTo { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        var content = (await output.GetChildContentAsync()).GetContent();
        var fullEmail = content + "@" + DomainName;
        output.Attributes.SetAttribute("href", "mailto:" + fullEmail);
        output.Content.SetContent(fullEmail);
        
        output.PreContent.SetHtmlContent("<strong>");
        output.PostContent.SetHtmlContent("</strong>");
    }
}