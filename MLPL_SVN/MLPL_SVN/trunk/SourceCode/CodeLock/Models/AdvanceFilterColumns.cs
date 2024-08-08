using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class AdvanceFilterColumns
    {
        public int SRNo { get; set; }
        public string SearchingColumnName { get; set; }
        public string SearchingColumnValue { get; set; }
        public string FieldType { get; set; }
        public string OperatorName { get; set; }
        public string SearchingLabelName { get; set; }
        public string CheckboxFieldName { get; set; }
        public bool IsCheckedField { get; set; }
    }
}