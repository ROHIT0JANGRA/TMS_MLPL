using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class OrderTrackingApi
    {

        public OrderTrackingApi()
        {
            this.PartList = new List<DocketPartListApi>();
        }
        public string DocketNo { get; set; }

        public string OrderNo { get; set; }
        public byte StatusCode { get; set; }
        public string DocketStatus { get; set; }

        public string DocketDateTime { get; set; }

        public string CurrentLocation { get; set; }

        public string CurrentStatusDateTime { get; set; }

        public string DeliveryDateTime { get; set; }

        public string Remark { get; set; }

        public List<DocketPartListApi> PartList { get; set; }

    }
    public class DocketPartListApi
    {
        public string PartName { get; set; }
        public int QtyShipped { get; set; }
        public int QtyDelivered { get; set; }
    }

    public class DocketTrackingResponseForFarEyeSuccess
    {
        public DocketTrackingResponseForFarEyeSuccess()
        {
            info = new OtherDocketInfoForFarEye();
        }
        public string order_no { get; set; }

        public string type { get; set; }

        public string value { get; set; }

        public string carrier_code { get; set; }

        public string carrier_status { get; set; }

        public string carrier_status_code { get; set; }

        public string carrier_status_description { get; set; }

        public string status_received_at { get; set; }

        public string event_timezone { get; set; }

        public string location_code { get; set; }

        public string location_name { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string last_updated_at { get; set; }

        public string status_identifier_value { get; set; }

        public string carrier_status_time_gmt { get; set; }

        public PodInfoForFarEye extra_info { get; set; }
        public OtherDocketInfoForFarEye info { get; set; }
        public string main_modality { get; set; }

    }
    public class PodInfoForFarEye
    {
        public PodInfoForFarEye()
        {
            pod = new List<PodLinkForFarEye>();
        }

        public string comments { get; set; }

        public string promised_delivery_date { get; set; }

        public string expected_delivery_date { get; set; }

        public string received_by { get; set; }

        public string relation { get; set; }

        public List<PodLinkForFarEye> pod { get; set; }

        public string signature { get; set; }

        public string customer_code { get; set; }

        public string customer_name { get; set; }

        public string epod { get; set; }

    }
    public class PodLinkForFarEye
    {
       //public string PodLink { get; set; }
    }
    public class OtherDocketInfoForFarEye
    {

    }
    public class DocketTrackingResponseForFarEyeFailure
    {
        public string order_no { get; set; }
        public string Status { get; set; }
    }

}