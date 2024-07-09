using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class PickupRequest : BaseModel
    {
        public long PickupRequestId { get; set; }

        [Display(Name = "Pickup Request No")]
        public string PickupRequestNo { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter the city")]
        public string City { get; set; }

        [Display(Name = "City")]
        public string CityId { get; set; }

        [Display(Name = "Pin Code")]
        [Required(ErrorMessage = "Please enter the pin code")]
        public string Pincode { get; set; }

        [Display(Name = "Pickup Date")]
        [Required(ErrorMessage = "Please enter the Pickup Date")]
        public DateTime PickupDate { get; set; }

        [Display(Name = "Pickup Time")]
        [Required(ErrorMessage = "Please enter the Pickup Time")]
        public DateTime PickupTime { get; set; }

        [Display(Name = "Contact Person")]
        [Required(ErrorMessage = "Please enter the Contact Person")]
        public string ContactPerson { get; set; }

        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Please enter the Mobile No")]
        [MobileAnnotation]
        public string MobileNo { get; set; }

        [Display(Name = "Email ID")]
        [EmailAnnotation]
        public string EmailId { get; set; }

        [Display(Name = "GST No")]
        [GstInNoAnnotation]
        public string GstNo { get; set; }

        [Display(Name = "Pickup Address")]
        [Required(ErrorMessage = "Please enter Pickup Address")]
        public string PickupAddress { get; set; }

        [Display(Name = "No of Pkt.")]
        [Required(ErrorMessage = "Please enter No of Pkt.")]
        public double NoofPkt { get; set; }

        [Display(Name = "Weight")]
        [Required(ErrorMessage = "Please enter Weight")]
        public double Weight { get; set; }

        [Display(Name = "ASN No")]
        public string ASNNo { get; set; }

        [Display(Name = "Delivery City")]
        [Required(ErrorMessage = "Please enter the city")]
        public string DeliveryCity { get; set; }

        [Display(Name = "Delivery City")]
        public string DeliveryCityId { get; set; }

        [Display(Name = "Delivery Pin Code")]
        [Required(ErrorMessage = "Please enter the pin code")]
        public string DeliveryPincode { get; set; }

        [Display(Name = "Customer Code")]
        [Required(ErrorMessage = "Customer Code")]
        public string CustomerCodeId { get; set; }

        [Display(Name = "Customer Code")]
        [Required(ErrorMessage = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "LocationId")]
        public short LocationId { get; set; }

        [Display(Name = "Vendor Name")]
        [Required(ErrorMessage = "Vendor Name")]
        public string VendorName { get; set; }

    }
}