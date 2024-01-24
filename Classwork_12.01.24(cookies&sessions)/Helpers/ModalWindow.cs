using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Classwork_12._01._24_cookies_sessions_.Helpers
{
    public class ModalWindow : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "modal-container");
            output.Attributes.SetAttribute("id", "modalContainer");
            output.Content.SetHtmlContent(this.HTMLBuilder());
        }

        public string HTMLBuilder()
        {
            StringBuilder str = new StringBuilder();

            str.Append("""
                <div class="modal-content">
                    <p>This is a modal window!</p>
                    <button class="continue-btn" onclick="closeModal()">Continue</button>
                </div>
                """);
            return str.ToString();
        }
    }
}
