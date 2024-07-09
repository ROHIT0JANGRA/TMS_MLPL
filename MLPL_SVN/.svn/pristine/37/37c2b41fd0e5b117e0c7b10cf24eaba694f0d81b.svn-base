//  
// Type: CodeLock.Models.LoadingSheet
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class LoadingSheet : BaseModel
    {
        [Display(Name = "Manual Manifest No")]
        [StringLength(50, ErrorMessage = "Manual Manifest No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        public string ManualManifestNo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Manifest Date")]
        [Required(ErrorMessage = "Please select Manifest Date")]
        public DateTime ManifestDate { get; set; }

        public long LoadingSheetId { get; set; }

        public string LoadingSheetNo { get; set; }

        [Display(Name = "Manual Loading Sheet No")]
        [StringLength(50, ErrorMessage = "Manual Loading Sheet No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        public string ManualLoadingSheetNo { get; set; }

        [Required(ErrorMessage = "Please select Loading Sheet Date And Time")]
        [Display(Name = "Loading Sheet Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime LoadingSheetDateTime { get; set; }

        public DateTime LoadingSheetDate { get; set; }

        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public short NextLocationId { get; set; }

        [Required(ErrorMessage = "Please enter Next Stop")]
        [Display(Name = "Next Stop")]
        public string NextLocationCode { get; set; }

        [Display(Name = "Transport Mode")]
        public byte TransportModeId { get; set; }

        [Display(Name = "Destination")]
        public string DestinationLocation { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        [Display(Name = "From City")]
        public int FromCityId { get; set; }

        public string FromCityName { get; set; }

        [Display(Name = "To City")]
        public int ToCityId { get; set; }

        public string ToCityName { get; set; }

        public string DocketNo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FromDocketDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ToDocketDate { get; set; }

        public short TotalDocket { get; set; }

        [Display(Name = "Total Packages")]
        public int TotalPackages { get; set; }

        [Display(Name = "Total Actual Weight")]
        public Decimal TotalActualWeight { get; set; }

        public string LoadingSheetStatus { get; set; }

        public string Remarks { get; set; }

        public List<LoadingSheetDocket> LoadingSheetDocketList { get; set; }
        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Customer Id")]
        public long CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Pickup ID")]
        public string PickupID { get; set; }
    }
}
