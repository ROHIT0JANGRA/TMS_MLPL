using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CodeLock.Models
{
    public class MasterPart : BaseModel
    {
        public MasterPart()
        {
            PartDetails = new List<MasterPartDetail>();
        }

        public long PartId { get; set; }

        
        public string PartCode { get; set; }

        [Required(ErrorMessage = "Please enter Part No")]
        //[Remote("IsPartNoAvailable", "Part", AdditionalFields = "PartId,_PartIdToken", ErrorMessage = "Part No already exists.", HttpMethod = "POST")]
        [StringLength(200, ErrorMessage = "Part No. must be minimum 3 character long", MinimumLength = 3)]
        [Display(Name = "Part No")]
        public string PartNo { get; set; }

        [Required(ErrorMessage = "Please enter Part Name")]
        //[Remote("IsPartNameAvailable", "Part", AdditionalFields = "PartId,_PartIdToken", ErrorMessage = "Part Name already exists.", HttpMethod = "POST")]
        [StringLength(200, ErrorMessage = "Part Name must be minimum 3 character long", MinimumLength = 3)]
        [Display(Name = "Part Name")]
        public string PartName { get; set; }
        [Display(Name = "Entry By")]
        public string UserName { get; set; }
        public int TotalParts { get; set; }
        public int FilterParts { get; set; }
        public List<MasterPartDetail> PartDetails { get; set; }
       
    }

    public class MasterPartDetail
    {
        public long PartId { get; set; }
        public short PackingTypeId { get; set; }
        public string PackingType { get; set; }
        public decimal ActualWeight { get; set; }
        public int Quantity { get; set; }
        public decimal ActualWeightPerQuantity { get; set; }
        public byte PackageDimensionsId { get; set; }
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public decimal CftRatio { get; set; }
        public decimal TotalCubic { get; set; }
        public decimal CubicPerQuantity { get; set; }
        public short ConsignorId { get; set; }
        public string ConsignorCode { get; set; }
        public short ConsigneeId { get; set; }
        public string ConsigneeCode { get; set; }
        public bool IsReverse { get; set; }
    }
}