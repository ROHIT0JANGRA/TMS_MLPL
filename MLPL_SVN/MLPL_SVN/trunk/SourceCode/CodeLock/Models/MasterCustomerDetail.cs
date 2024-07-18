using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
    public class MasterCustomerDetail
    {

        [StringLength(30, ErrorMessage = "Password must be minimum 6 and maximum 30 character long", MinimumLength = 6)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Display(Name = "Pan No")]
        [PanNoAnnotation]
        //[Required(ErrorMessage = "Please Enter Pan No")]
        public string PanNo { get; set; }

        [Display(Name = "GstTin No")]
        [GstInNoAnnotation]
        //[Required(ErrorMessage = "Please Enter Gst No")]
        public string GstTinNo { get; set; }

        [Display(Name = "Industry")]
        [Required(ErrorMessage = "Please select Industry")]
        public string IndustryId { get; set; }

       public string IndustryName { get; set; }


        [Display(Name = "Ownership Type")]
        [Required(ErrorMessage = "Please select Ownership Type")]
        public string TypeOfOwnershipId { get; set; }
        public string TypeOfOwnershipName { get; set; }

        [Display(Name = "Mobile No")]
        //[Required(ErrorMessage = "Please enter Mobile No")]
        [MobileAnnotation]
        public string MobileNo { get; set; }

        [Display(Name = "Email Id")]
        //[EmailAnnotation]
        //[Required(ErrorMessage = "Please enter Email Id")]
        public string EmailId { get; set; }

        [Display(Name = "Customer Location")]
        [Required(ErrorMessage = "Please select At-least one thing")]
        public string CustomerLocation { get; set; }

        [Display(Name = "Customer Delivery Location")]
        [Required(ErrorMessage = "Please select At-least one thing")]
        public string CustomerDeliveryLocation { get; set; }


        [Display(Name = "Name")]
        public string DecisionMakerName { get; set; }
        [Display(Name = "Designation")]
        public string DecisionMakerDesignation { get; set; }

        [Display(Name = "Mobile No")]
        public string DecisionMakerMobileNo { get; set; }

        [Display(Name = "EmailId")]
        [EmailAnnotation]
        public string DecisionMakerEmailId { get; set; }
        [Display(Name = "Name")]
        public string SalesPersonBookingDealName { get; set; }
        [Display(Name = "Designation")]
        public string SalesPersonBookingDealDesignation { get; set; }

        [Display(Name = "Mobile No")]
        public string SalesPersonBookingDealMobileNo { get; set; }

        [Display(Name = "EmailId")]
        //[Required(ErrorMessage = "Please enter Email Id")]
        [EmailAnnotation]
        public string SalesPersonBookingDealEmailId { get; set; }

        [Display(Name = "Name")]
        public string SalesPersonClosingDealName { get; set; }
        [Display(Name = "Designation")]
        public string SalesPersonClosingDealDesignation { get; set; }

        [Display(Name = "Mobile No")]
        public string SalesPersonClosingDealMobileNo { get; set; }

        [Display(Name = "EmailId")]
        [EmailAnnotation]
        public string SalesPersonClosingDealEmailId { get; set; }

        [Display(Name = "Entry By")]
        public short EntryBy { get; set; }

        [Display(Name = "Milkrun Hrs/Day")]
        public bool IsMilkrunHrsPerDayEnabled { get; set; }

        [Display(Name = "Lane ID")]
        public bool IsLaneID { get; set; }
        [Display(Name = "Is Truck Forward Note")]
        public bool IsTruckForwardNote { get; set; }

        [Display(Name = "Customer Type")]
        [Required(ErrorMessage = "Please select Customer Type")]
        public Byte CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        [Display(Name = "Phone No")]
        //[Required(ErrorMessage = "Please enter Phone No.")]
        public string PhoneNo { get; set; }

    }
}