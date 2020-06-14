using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETB.Utilities
{
    public static class ExtentionMethods
    {
        public static string EmptyIfNull(this string value) => value?.ToString() ?? string.Empty;

        public static IEnumerable<SelectListItem> GetEnumTextSelectList<TEnum>(this IHtmlHelper htmlHelper) where TEnum : struct
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.ToString(),
                        Value = x.ToString()
                    }), "Value", "Text");
        }


        private static string MessageDetails(this Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{DateTime.Now} : ");
            sb.Append($"Error Message: {ex.Message} | Error Source : {ex.Source} | Exception Type : {ex.GetType().Name}");
            if (ex.StackTrace != null)
            {
                sb.Append(System.Environment.NewLine);
                sb.Append("Error Trace : " + ex.StackTrace);
            }
            Exception innerEx = ex.InnerException;
            string tab = "";
            while (innerEx != null)
            {
                tab += "\t";
                sb.Append(System.Environment.NewLine);
                sb.Append($"{tab}Inner Error Message: {innerEx.Message} | Error Source : {innerEx.Source} | Exception Type : {innerEx.GetType().Name}");

                if (innerEx.StackTrace != null)
                {
                    sb.Append(System.Environment.NewLine);
                    sb.Append($"{tab}Inner Error Trace : {innerEx.StackTrace}");
                }
                innerEx = innerEx.InnerException;
            }
            return sb.ToString();
        }
    }
}
