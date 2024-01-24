using Classwork_12._01._24_cookies_sessions_.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Classwork_12._01._24_cookies_sessions_.Helpers
{
    public class InputSearchTagHelper : TagHelper
    {
        public List<Category>? Categories { get; set; }
        public string? SelectedInputValue { get; set; }
        public string? SelectedCategory { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "input-group mt-3");
            output.Content.SetHtmlContent(this.HTMLBuilder());
        }

        public string HTMLBuilder()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"""
                       <input type="text" id="myinput" class="form-control" placeholder="Search for product name..." name="input" value={SelectedInputValue}>
                          <select id="category" class="form-select" name="categoryId" onchange="handleCategoryChange()">
                    """);

            for (int i = 0; i < Categories.Count; i++)
            {
               if(SelectedCategory != null)
                {
                    int index = -1;
                    for (int j = 0; j < Categories.Count; j++)
                    {
                        if (Categories[j].Name.Equals(SelectedCategory))
                        {
                            index = j;
                            break;
                        }
                    }

                    if(index == i)
                    {
                        str.Append($"<option selected value=\"{Categories[i].Id}\">{Categories[i].Name}</option>\n");
                    }
                    else
                    {
                        str.Append($"<option value=\"{Categories[i].Id}\">{Categories[i].Name}</option>\n");
                    }
                } 
            }

            str.Append("</select>\n");

            str.Append("""
                <div class="input-group-append">
                    <button id="searchButton" class="btn btn-primary" onClick="check()" type="button">Search</button>
                    <a class="btn btn-primary" href="/home/showcart" role="button">Show cart</a>
                </div>
                """);
            return str.ToString();
        }
    }
}
