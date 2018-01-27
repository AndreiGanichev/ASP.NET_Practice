using ASP.NET_Practice.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace ASP.NET_Practice.Helpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString GetPageLinks(this HtmlHelper html, int totalPageNumber, int currentPageNumber, Func<int, string> pageUrl)
        {
            var listBuilder = new StringBuilder();        
            TagBuilder aTag = null;
            TagBuilder liTag = null;

            for(int i = 1; i<= totalPageNumber; i++)
            {
                liTag = new TagBuilder("li");
                aTag = new TagBuilder("a");
                aTag.InnerHtml = i.ToString();
                
                if(i == currentPageNumber)
                {
                    aTag.AddCssClass("active");
                    aTag.MergeAttribute("href", "#");
                }
                else
                {
                    aTag.MergeAttribute("href", pageUrl.Invoke(i));
                }

                liTag.InnerHtml = aTag.ToString();
                listBuilder.Append(liTag.ToString());
            }

            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.InnerHtml = listBuilder.ToString();
            return MvcHtmlString.Create(ulTag.ToString());
        }
    }
}