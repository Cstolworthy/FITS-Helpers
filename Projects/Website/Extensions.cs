using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Website
{
    public static class Extensions
    {

        public static List<SelectListItem> ToSelectItemList(this IEnumerable<string> strings)
        {
            return strings.Select(@string => new SelectListItem() {Selected = false, Text = @string, Value = @string}).ToList();
        }
    }
}