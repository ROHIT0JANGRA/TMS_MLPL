using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class RivigoModel
    {
    }

    public class CreateBookingDto
    {
        public int scheduledBookingDateTime { get; set; }
        public FromClientContactDetailsDto fromAddress { get; set; }
    }
    public class FromClientContactDetailsDto
    {
        public FromClientAddressDto addressDetails { get; set; }
        public FromCallDetailsDto callDetails { get; set; }
        public FromCompanyDetailsDto companyDetails { get; set; }
        public List<CreateIndividualBookingDto> individualBookingList { get; set; }

    }
    public class CreateIndividualBookingDto
    {
        public string cnote { get; set; }
        public List<ToClientContactDetailsDto> toAddressList { get; set; }
        public PartTruckLoadDetailsDto loadDetails { get; set; }

    }
    public class ToClientContactDetailsDto
    {
        public FromClientAddressDto addressDetails { get; set; }
        public FromCallDetailsDto callDetails { get; set; }
        public FromCompanyDetailsDto companyDetails { get; set; }
    }
    public class PartTruckLoadDetailsDto
    {


    }

    //
    public class FromCompanyDetailsDto
    {
        public string companyName { get; set; }
        public string GSTIN { get; set; }
        public string PAN { get; set; }


    }
    public class FromClientAddressDto
    {
        public string detailedAddress { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int floorNumber { get; set; }

    }
    public class FromCallDetailsDto
    {
        public string name { get; set;}
        public string phone { get; set; }
        public string email { get; set; }

    }

    public class RivigoAuthApiResponse
    {
        public int statusCode { get; set; }
        public string status { get; set; }
        public RivigoBearer payload { get; set; }
    }
    public class RivigoBearer
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }
        public string jti { get; set; }


    }

    //
}