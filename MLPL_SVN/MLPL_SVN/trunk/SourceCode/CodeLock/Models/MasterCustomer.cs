﻿//  
// Type: CodeLock.Models.MasterCustomer
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace CodeLock.Models
{
    public class MasterCustomer : BaseModel
    {

        public MasterCustomer()
        {
            this.MasterCustomerDetail = new MasterCustomerDetail();
            this.MasterCustomerAddressInfo = new Models.MasterCustomerAddressInfo();
        }

        public short CustomerId { get; set; }

        [Display(Name = "System Code")]
        public string SystemCode { get; set; }


        [Display(Name = "Group Code")]
        [Required(ErrorMessage = "Please select group code")]
        public string GroupCode { get; set; }

        [Display(Name = "Group Code")]
        public string GroupName { get; set; }



        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }


        [Display(Name = "Customer Name")]
        [StringLength(100, ErrorMessage = "Customer Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter Customer Name")]
        [Remote("IsCustomerNameAvailable", "Customer", AdditionalFields = "CustomerId,_CustomerIdToken", ErrorMessage = "Customer Name already exists.", HttpMethod = "POST")]
        public string CustomerName { get; set; }

        public string CustomerLocation { get; set; }
        public string CustomerDeliveryLocation { get; set; }

        [Display(Name = "PayBasId")]
        public string PayBasId { get; set; }

        [Display(Name = "PayBas")]
        public string PayBasName { get; set; }

        [Display(Name = "Customer Location")]
        public string SavedCustomerLocation { get; set; }

        [Display(Name = "Customer Delivery Location")]
        public string SavedCustomerDeliveryLocation { get; set; }

        public bool IsMilkrunHrsPerDayEnabled { get; set; }
        [Display(Name = "PayBas")]
        public MasterGeneral[] PayBas { get; set; }

        public MasterCustomerDetail MasterCustomerDetail { get; set; }
        public MasterCustomerAddressInfo MasterCustomerAddressInfo { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Pincode { get; set; }
        public string GstTinNo { get; set; }
        public int TotalCustomers { get; set; }
        public int FilterCustomers { get; set; }
        public bool IsWalkIn { get; set; }
        public string PanNo { get; set; }
        public string PhoneNo { get; set; }
        public string PanNoMobileNo { get; set; }
    }
    public class CustomerDetail
    {
        public string CustomerCode { get; set; }
        public string GroupCode { get; set; }
        public string CustomerName { get; set; }
        public string GstTinNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Pincode { get; set; }
        public bool IsWalkIn { get; set; }
    }
    public class GetBycustomerName
    {
        public short CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class CustomerExcelData 
    {
        public string GroupName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string IndustryName { get; set; }
        public string GstTinNo { get; set; }
        public bool IsActive { get; set; }
        public string TypeOfOwnershipName { get; set; }
        public string CustomerLocation { get; set; }
        public string PayBasName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityName { get; set; }
       public string Pincode { get; set; }
        public string UpdateByName { get; set; }
        public string UpdateDate { get; set; }
        public string EntryByName { get; set; }
        public string EntryDate { get; set; }
    }
}