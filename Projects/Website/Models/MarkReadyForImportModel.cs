using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Website.Models
{
    public class MarkReadyForImportModel
    {
        public IEnumerable<string> ColumnNames { get; set; }
        public List<SelectListItem> ColumnsAsSelect { get { return ColumnNames.ToSelectItemList(); } }
    }
}