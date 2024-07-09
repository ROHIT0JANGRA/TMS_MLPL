using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
	public class DocketStatusDetailApi
	{
		public long RowNumber { get; set; }

		public string StatusDateTime { get; set; }

		public string StatusLocation { get; set; }

		public string Status { get; set; }
	}
}