using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.MVC.Helper.Entity;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Galaxy.MVC.Helper.Helpers
{
    [HtmlTargetElement("list-articles")]
    public class ArticleTagHelper : TagHelper
    {
        public ModelExpression Articles { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Article> articles = (List<Article>)Articles.Model;
            TagBuilder divListGroup = new TagBuilder("div");


            divListGroup.AddCssClass("list-group");

            articles.ForEach(article =>
            {
                TagBuilder divListGroupItem = new TagBuilder("div");
                TagBuilder divDFlex = new TagBuilder("div");
                TagBuilder h5Title = new TagBuilder("h5");
                TagBuilder smallLastTime = new TagBuilder("small");
                TagBuilder pBody = new TagBuilder("p");
                TagBuilder smallFooter = new TagBuilder("small");

                divListGroupItem.AddCssClass("list-group-item list-group-item-action");
                divDFlex.AddCssClass("d-flex w-100 justify-content-between");
                h5Title.AddCssClass("mb-1");
                smallLastTime.AddCssClass("text-muted");
                pBody.AddCssClass("mb-1");
                smallFooter.AddCssClass("text-muted");

                h5Title.InnerHtml.Append(article.Title);
                smallLastTime.InnerHtml.Append(article.LastTime);
                pBody.InnerHtml.Append(article.Body);
                smallFooter.InnerHtml.Append(article.Footer);

                divDFlex.InnerHtml.AppendLine(h5Title);
                divDFlex.InnerHtml.AppendLine(smallLastTime);
                divListGroupItem.InnerHtml.AppendLine(divDFlex);
                divListGroupItem.InnerHtml.AppendLine(pBody);
                divListGroupItem.InnerHtml.AppendLine(smallFooter);

                divListGroup.InnerHtml.AppendLine(divListGroupItem);
            });

            output.Content.SetHtmlContent(divListGroup);
        }
    }
}
