using Galaxy.MVC.Helper.Entity;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.MVC.Helper.Helpers
{
    public static class HtmlHelperExtension
    {
        public static IHtmlContent ArticleStringBuilder<TModel,TProperty>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);
            List<Article> articles = (List<Article>)metadata.Model;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<div class='list-group'>");
            articles.ForEach(article =>
            {
                
                stringBuilder.AppendLine(" <div class='list-group-item list-group-item-action'>");
                stringBuilder.AppendLine("     <div class='d-flex w-100 justify-content-between'>");
                stringBuilder.AppendLine("         <h5 class='mb-1'>"+ article.Title + "</h5>");
                stringBuilder.AppendLine("         <small class='text-muted'>"+ article.LastTime + "</small>");
                stringBuilder.AppendLine("     </div>");
                stringBuilder.AppendLine("     <p class='mb-1'>"+ article.Body + "</p>");
                stringBuilder.AppendLine("     <small class='text-muted'>"+ article.Footer + "</small>");
                stringBuilder.AppendLine(" </div>");                
            });
            stringBuilder.AppendLine("</div>");

            return new HtmlString(stringBuilder.ToString());
        }

        public static IHtmlContent ArticleTagBuilder<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);
            List<Article> articles = (List<Article>)metadata.Model;
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

            return divListGroup;
        }

    }
}
