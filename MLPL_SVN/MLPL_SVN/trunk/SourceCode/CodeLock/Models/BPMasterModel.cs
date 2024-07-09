using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{

    public class BPMasterModel
    {
        public string CardCode { get; set; }
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
        public string U_Controling_Branch { get; set; }
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
            public string BPCode { get; set; }
            public int RowNum { get; set; }
            public string GSTIN { get; set; }
            public string GstType { get; set; }
            public string CreateDate { get; set; }
            public string CreateTime { get; set; }
            public string U_PANNo { get; set; }
        }

        public class ContactEmployee
        {
            public string CardCode { get; set; }
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
            public string BPCode { get; set; }
            public string Branch { get; set; }
            public string Country { get; set; }
            public string BankCode { get; set; }
            public string AccountNo { get; set; }
            public string AccountName { get; set; }
            public string BICSwiftCode { get; set; }
        }

     
    
}