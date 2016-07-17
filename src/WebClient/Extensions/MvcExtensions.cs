using PagedList;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Dramonkiller.CareHomeApp.WebClient.Extensions
{
    public static class MvcExtensions
    {
        #region Extensions for IPagedList

        public static MvcHtmlString DisplayNameFor<TModel, TValue>(this HtmlHelper<IPagedList<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            return DisplayNameForInternal(html, expression);
        }

        private static MvcHtmlString DisplayNameForInternal<TModel, TValue>(this HtmlHelper<IPagedList<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            return DisplayNameHelper(ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>()),
                                     ExpressionHelper.GetExpressionText(expression));
        }

        private static MvcHtmlString DisplayNameHelper(ModelMetadata metadata, string htmlFieldName)
        {
            string resolvedDisplayName = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            return new MvcHtmlString(HttpUtility.HtmlEncode(resolvedDisplayName));
        }

        #endregion

        public static MvcHtmlString StylesRenderWithVersion(string path)
        {
            IHtmlString value = Styles.Render(path);
            string stringValue = value.ToHtmlString();
            const string searchString = ".css\"";

#if DEBUG

            int index = stringValue.IndexOf(searchString);

            if (index > -1)
            {
                return new MvcHtmlString(stringValue.Insert(index + searchString.Length - 1, string.Format("?v={0:yyyyMMddHHmmss}", DateTime.Now))); 
            }
#endif

            return new MvcHtmlString(stringValue);
        }


    }
}