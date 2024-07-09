using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DocketListByTripsheetApi
    {
        public DocketListByTripsheetApi()
        {
            this.TripsheetDocketDetails = new List<DocketListByTripsheetApiResponse>();
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<DocketListByTripsheetApiResponse> TripsheetDocketDetails { get; set; }

    }
    public class DocketListByTripsheetApiResponse
    {
        public DocketListByTripsheetApiResponse()
        {
            this.DocketCartonList = new List<DocketCarton>();
        }
        public long DocketId { get; set; }
        public string DocketNo { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string ConsignorName { get; set; }
        public string ConsigneeName { get; set; }
        public int TotalPackages { get; set; }
        public List<DocketCarton> DocketCartonList { get; set; }

    }

    public class DocketCarton
    {
        public string CartonNo { get; set; }
         
    }

    public class ApiSubmitScanRequest
    {
        public long DocketId { get; set; }
        public string DocketSuffix { get; set; }

        public string DocketNo { get; set; }

        public string CartonNo { get; set; }
    }
    public class ApiSubmitScanResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class DocketCartonListByTripsheetResponse
    {
        public DocketCartonListByTripsheetResponse()
        {
            this.TripsheetDocketCartonList = new List<TripsheetDocketCarton>();
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<TripsheetDocketCarton> TripsheetDocketCartonList { get; set; }

    }

    public class TripsheetDocketCarton
    {
        public string CNoteNo { get; set; }
        public string BarCodeNo { get; set; }
        public int TotalBox { get; set; }
        public string Shortcode { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string RefNo { get; set; }
        public string BarCodeNoPrint { get; set; }
    }
    public class TripsheetRequest
    {
        public string tripsheetNo { get; set; }
    }
}