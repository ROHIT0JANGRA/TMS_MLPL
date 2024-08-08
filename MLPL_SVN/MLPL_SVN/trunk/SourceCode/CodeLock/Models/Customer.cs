
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Customer
  {
    [Display(Name = "Customer")]
    public string CustomerCode { get; set; }

    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }

    [Display(Name = "Customer Id")]
    public int CustomerId { get; set; }

        public string GstTinNo { get; set; }

    }
    public class BPMasterModel
    {
        public BPMasterModel()
        {
            this.ContactEmployees = new List<ContactEmployee>();
            this.BPBankAccounts = new List<BPBankAccount>();
            //this.BusinessPartnerDetails = new BusinessPartnerDetails();
            this.BPAddresses = new List<BPAddress>();
        }
        public int Series { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int GroupCode { get; set; }
        public int PayTermsGrpCode { get; set; }
        public int SalesPersonCode { get; set; }
        public string DefaultAccount { get; set; }
        public string DefaultBranch { get; set; }
        public string DefaultBankCode { get; set; }
        public string CompanyPrivate { get; set; }
        public int Industry { get; set; }
        public List<BPAddress> BPAddresses { get; set; }
        public List<ContactEmployee> ContactEmployees { get; set; }
        public List<BPBankAccount> BPBankAccounts { get; set; }
    }

    public class BPAddress
    {
        public string AddressName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string AddressType { get; set; }
        public string AddressName2 { get; set; }
        public string AddressName3 { get; set; }
        public int RowNum { get; set; }
        public string GSTIN { get; set; }
        public string GstType { get; set; }   
        public string U_PANNo { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
    }

    public class ContactEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string E_Mail { get; set; }
        public string Title { get; set; }
        public string Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class BPBankAccount
    {   
        public string Branch { get; set; }
        public string Country { get; set; }
        public string BankCode { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string BICSwiftCode { get; set; }
    }
    public class BpMasterTable
    {
        [JsonProperty("CardCode")]
        public string CardCode { get; set; }

        [JsonProperty("CardName")]
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int GroupCode { get; set; }
        public string CreateDate { get; set; }
        [JsonProperty("BPAddresses")]
        public List<BPAddress> BPAddresses { get; set; }

    }
    public class BpMasterTableResponse
    {
        [JsonProperty("value")]
        public List<BpMasterTable> Value { get; set; }
    }
}
