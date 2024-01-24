using Classwork_12._01._24_cookies_sessions_.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Classwork_12._01._24_cookies_sessions_.Helpers
{
    public class OrderListTagHelper : TagHelper
    {
        public Cart Cart { get; set; }
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
                            <th scope="col">#</th>
                            <th scope="col">Ordered name</th>
                            <th scope="col">Ordered amount</th>
                        </tr>
                    </thead>
                """);

            int count = 1;
            str.AppendLine("<tbody>");
            foreach (var product in Cart.ChosenProducts)
            {
                str.AppendLine($"""
                            <tr">
                                <td>
                                    {count++}
                                </td>
                                <td>
                                    {product.Name}
                                </td>
                                <td>
                                    {product.Amount}
                                </td>
                            </tr>
                    """);
            }

            str.AppendLine("</tbody>");

            return str.ToString();
        }
    }
}
