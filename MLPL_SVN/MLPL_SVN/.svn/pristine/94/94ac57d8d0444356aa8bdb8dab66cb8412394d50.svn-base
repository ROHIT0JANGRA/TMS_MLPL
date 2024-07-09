using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class VendorContractChargeMatrixSTD : Base
    {
        public VendorContractChargeMatrixSTD()
        {
            this.BillLocationId = new short?((short)1);
            this.BillLocation = "HQTR";
        }
        [Key]
        public short ContractId { get; set; }

        public string ContractNo { get; set; }

        [Display(Name = "Transport Mode")]
        [Required(ErrorMessage = "Please select Transport Mode")]
        public byte TransportModeId { get; set; }

        [Display(Name = "Transport Mode")]
        public string TransportMode { get; set; }

        public bool IsBooking { get; set; }

        [Required(ErrorMessage = "Please select Charge")]
        [Display(Name = "Charge")]
        public byte ChargeCode { get; set; }

        [Display(Name = "Charge Type")]
        public string ChargeCodeType { get; set; }

        public byte BaseOn1 { get; set; }

        public byte BaseCode1 { get; set; }

        public byte BaseOn2 { get; set; }

        [Display(Name = "Base Code")]
        public byte BaseCode2 { get; set; }

        [Display(Name = "FTL Type")]
        public byte FtlTypeId { get; set; }

        [Display(Name = "FTL Type")]
        public string FtlType { get; set; }

        [Required(ErrorMessage = "Please select Matrix Type")]
        [Display(Name = "Matrix Type")]
        public byte MatrixType { get; set; }

        [Display(Name = "Matrix Type")]
        public string Matrix { get; set; }

        [Display(Name = "From")]
        public short FromLocation { get; set; }

        [Display(Name = "From")]
        public string From { get; set; }

        [Display(Name = "To")]
        public short ToLocation { get; set; }

        [Display(Name = "To")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter Rate")]
        [Display(Name = "Rate")]
        public Decimal Rate { get; set; }

        [Required(ErrorMessage = "Please select Rate Type")]
        [Display(Name = "Rate Type")]
        public byte RateType { get; set; }

        [Display(Name = "Rate Type")]
        public string RateTypeDescription { get; set; }

        [Display(Name = "Transit Days")]
        public byte TransitDays { get; set; }

        [Display(Name = "Bill Location")]
        public short? BillLocationId { get; set; }

        [Display(Name = "Bill Location")]
        public string BillLocation { get; set; }

        [Display(Name = "Prorata App (Y/N)")]
        public bool UseProRata { get; set; }

        [Display(Name = "Prorata Method")]
        public string ProRataType { get; set; }

        [Display(Name = "Prorata Rate In Kg.")]
        public Decimal ProRata { get; set; }

        [Required(ErrorMessage = "Please enter From")]
        public string FromLocationCode { get; set; }

        [Required(ErrorMessage = "Please enter To")]
        public string ToLocationCode { get; set; }

        [Required(ErrorMessage = "Please enter Bill Location")]
        public string BillLocationCode { get; set; }

        public bool BillLocationEditable { get; set; }

        [Display(Name = "Consignor")]
        public short ConsignorId { get; set; }

        [Display(Name = "Consignor")]
        [Required(ErrorMessage = "Please select Consignor")]
        public string ConsignorName { get; set; }

        [Display(Name = "Consignee")]
        public short ConsigneeId { get; set; }

        [Required(ErrorMessage = "Please select Consignee")]
        [Display(Name = "Consignee")]
        public string ConsigneeName { get; set; }

        [Display(Name = "Upload Status")]
        public string UploadStatus { get; set; }

        [Display(Name = "Is Reverse")]
        public bool IsReverse { get; set; }

        public List<CustomerContractChargeMatrixSTD> Details { get; set; }
    }
}
