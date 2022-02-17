using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Struct
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class CustomTagHelper : TagHelper
    {
        private IUrlHelperFactory uhf;
        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public CustomTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder builder = new TagBuilder("div");
            for (int i = 0; i < PageModel.NumberOfPages; i++)
            {
                TagBuilder tbd = new TagBuilder("a");
                tbd.Attributes["href"] = uh.Action(PageAction, new { pageNum = i + 1 });
                tbd.InnerHtml.Append((i+1).ToString());
                tbd.AddCssClass(PageClass);
                tbd.AddCssClass(i + 1 == PageModel.PageNum
                    ? PageClassSelected : PageClassNormal);
                builder.InnerHtml.AppendHtml(tbd);
            }

            output.Content.AppendHtml(builder.InnerHtml);
        }
    }
}
