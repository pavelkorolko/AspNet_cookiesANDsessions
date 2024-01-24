using Classwork_12._01._24_cookies_sessions_.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Classwork_12._01._24_cookies_sessions_.Helpers
{
    public class ProductListTagHelper : TagHelper
    {
        public IEnumerable<Product>? Products { get; set; }
        public int UserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "table table-hover");
            output.Content.SetHtmlContent(this.BuildUserListHtml());
        }

        private string BuildUserListHtml()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("""
                    <thead>
                        <tr>
                            <th scope="col">Name</th>
                            <th scope="col">Description</th>
                            <th scope="col">Picture</th>
                        </tr>
                    </thead>
                """);

            str.AppendLine("<tbody>");
            foreach (var product in Products)
            {
                str.AppendLine($"""
                            <tr onclick="window.location.href= '/home/details?userId={UserId}&productId={product.Id}'">
                                <td>
                                    {product.Name}
                                </td>
                                <td>
                                    {product.Description}
                                </td>
                                <td>
                                    <img src="{product.Picture}"/>
                                </td>
                            </tr>
                    """);
            }

            str.AppendLine("</tbody>");

            return str.ToString();
        }
    }
}
