using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Collections.Generic;
namespace CodeLock.Models
{

    public class MasterCustomer : BaseModel
    {

        public MasterCustomer()
        {
            this.MasterCustomerDetail = new MasterCustomerDetail();
            this.MasterCustomerAddressInfo = new Models.MasterCustomerAddressInfo();
            //this.BusinessPartnerDetails = new BusinessPartnerDetails();
            this.MasterAddressList = new List<MasterAddress>();      
        }
        public int groupCodeSelectedId { get; set; }
        public short CustomerId { get; set; }

        [Display(Name = "System Code")]
        public string SystemCode { get; set; }


        [Display(Name = "Group Code")]
        [Required(ErrorMessage = "Please select group code")]
        public string GroupCode { get; set; }

        [Display(Name = "Group Code")]
        public string GroupName { get; set; }


        public string U_Controling_Branch { get; set; } // Corresponds to 'U_Controling_Branch'

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


        public int TotalCustomers { get; set; }
        public int FilterCustomers { get; set; }
        public string PhoneNo { get; set; }

        // *************************** Adding InsertBp Models Required Fields ****************************************

        [Required(ErrorMessage = "At least a Secondory Address is required")]
        public List<MasterAddress> MasterAddressList { get; set; }
        //public BusinessPartnerDetails BusinessPartnerDetails { get; set; }
        public bool IsAddressMapped { get; set; }
        public bool IsGSTMapped { get; set; }
        // Payment Terms
        [Display(Name = "Payment Terms")]
        public string PaymentTerms { get; set; }

        [Display(Name = "Interest On Arrears Percentage")]
        public decimal? InterestOnArrearsPercentage { get; set; }

        [Display(Name = "Price List")]
        public string PriceList { get; set; }
        [Display(Name = "Total Discount Percentage")]

        public decimal? TotalDiscountPercentage { get; set; }

        // Credit Limit and Commitment Limit
        [Display(Name = "Credit Limit")]

        public decimal? CreditLimit { get; set; }
        [Display(Name = "Commitment Limit")]

        public decimal? CommitmentLimit { get; set; }
        [Display(Name = "Dunning Term")]

        public string DunningTerm { get; set; }
        [Display(Name = "Effective Discounts Groups")]

        public string EffectiveDiscountsGroups { get; set; }

        // Business Partner Bank
        [Display(Name = "Bank Country Regions")]
        public string BankCountryRegion { get; set; }
        [Display(Name = "Bank Name")]
        public string BPCode { get; set; }
        public string BankName { get; set; }
        [Display(Name = "Bank Code")]

        public string BankCode { get; set; }
        [Display(Name = "Account")]

        public string Account { get; set; }
        [Display(Name = "BICSWIFT Code")]

        public string BICSWIFTCode { get; set; }
        [Display(Name = "Bank Account Name")]

        public string BankAccountName { get; set; }
        [Display(Name = "Branch")]

        public string Branch { get; set; }
        [Display(Name = "CtrlIntID")]

        public string CtrlIntID { get; set; }

        // Mandate Details
        [Display(Name = "MandateID")]

        public string MandateID { get; set; }
        [Display(Name = "Date Of Signature")]

        public string DateOfSignature { get; set; }
        [Display(Name = "Address Code")]

        public string AddressCode { get; set; }
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




