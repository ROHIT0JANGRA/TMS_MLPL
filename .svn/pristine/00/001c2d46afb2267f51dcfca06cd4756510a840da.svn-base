using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
	public class DocketStatusApi
	{
		public DocketStatusApi()
		{
			this.DocketInvoiceList = new List<DocketInvoiceApi>();
		}
		public long DocketId { get; set; }

		public string DocketNo { get; set; }

		public string DocketSuffix { get; set; }

		public string ReferanceNo { get; set; }

		public string DocketStatus { get; set; }

		public string DocketDateTime { get; set; }

		public string CurrentLocation { get; set; }

		public string ToLocation { get; set; }

		public string ReceiverName { get; set; }

		public string PodUrl { get; set; }

		public string Origin { get; set; }

		public string Destination { get; set; }

		public string CurrentStatusDateTime { get; set; }

		public string DeliveryDateTime { get; set; }
        public string EDD { get; set; }
        public string Consignor { get; set; }
        public string Consignee { get; set; }
        public string PickupDate { get; set; }

        public IEnumerable<DocketStatusDetailApi> DocketStatusDetailApiList { get; set; }

		public List<DocketInvoiceApi> DocketInvoiceList { get; set; }

		public bool IsSuccess { get; set; }
		public string Message { get; set; }

	}
}