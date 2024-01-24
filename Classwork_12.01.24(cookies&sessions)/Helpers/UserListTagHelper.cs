using Classwork_12._01._24_cookies_sessions_.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Classwork_12._01._24_cookies_sessions_.Helpers
{
    public class UserListTagHelper : TagHelper
    {
        public IEnumerable<User>? Users { get; set; }
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
                            <th scope="col">Name</th>
                            <th scope="col">Email</th>
                        </tr>
                    </thead>
                """);

            int count = 1;
            str.AppendLine("<tbody>");
            foreach (var user in Users)
            {
                str.AppendLine($"""
                            <tr onclick="window.location.href= '/home/setuser/{user.Id}'">
                                <td>
                                    {count++}
                                </td>
                                <td>
                                    {user.Name}
                                </td>
                                <td>
                                    {user.Email}
                                </td>
                            </tr>
                    """);
            }

            str.AppendLine("</tbody>");

            return str.ToString();
        }
    }
}
