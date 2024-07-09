//  
// Type: CodeLock.Models.MasterLocation
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
	public class MasterLocation : BaseModel
	{
		public short LocationId { get; set; }

		[Required(ErrorMessage = "Please select Location Hierarchy")]
		[Display(Name = "Location Hierarchy")]
		public byte LocationHierarchyId { get; set; }

		[Required(ErrorMessage = "Please select Reporting To")]
		[Display(Name = "Reporting To")]
		public byte LocationHierarchyReportingToId { get; set; }

		public string LocationHierarchyName { get; set; }

		public string ReportLocationHierarchy { get; set; }

		public string ReportLocationHierarchyName { get; set; }

		public string Reportlocation { get; set; }

		[Display(Name = "Ownership Location")]
		public string ownershipLocationId { get; set; }

		public string OwnershipLocation { get; set; }
		//ReportLocationHierarchy

		//Reportlocation

		[Remote("IsLocationCodeAvailable", "Location", AdditionalFields = "LocationId,_LocationIdToken", ErrorMessage = "Location Code already exists", HttpMethod = "POST")]
		[StringLength(10, ErrorMessage = "Location Code must be minimum 2 and maximum 10 character long", MinimumLength = 2)]
		[Required(ErrorMessage = "Please enter Location Code")]
		[Display(Name = "Location Code")]
		public string LocationCode { get; set; }

		[Display(Name = "Location Name")]
		[Required(ErrorMessage = "Please enter Location Name")]
		public string LocationName { get; set; }

		[Display(Name = "Country Name")]
		[Required(ErrorMessage = "Please select Country Name")]
		public string CountryNameId { get; set; }

		public string CountryName { get; set; }

		[Display(Name = "State Name")]
		[Required(ErrorMessage = "Please select State Name")]
		public string StateNameId { get; set; }
		public string StateName { get; set; }

		public string StateId { get; set; }

		[Display(Name = "Reporting Location")]
		[Required(ErrorMessage = "Please select Reporting Location")]
		public string ReportLocationId { get; set; }

		[Display(Name = "Country Name")]
		[Required(ErrorMessage = "Please select Country Name")]
		public string CountryId { get; set; }

		[Display(Name = "City Name")]
		[Required(ErrorMessage = "Please select City Name")]
		public string CityId { get; set; }

		public string CityName { get; set; }

		[Display(Name = "Pin code")]
		[Required(ErrorMessage = "Please enter Pin code")]
		public string Pincode { get; set; }

		[Display(Name = "Address")]
		[Required(ErrorMessage = "Please enter Address")]
		public string Address { get; set; }

		[Display(Name = "Mobile No")]
		[StringLength(10, ErrorMessage = "Mobile No must be 10 character long", MinimumLength = 0)]
		[Required(ErrorMessage = "Please enter Mobile No")]
		public string MobileNo { get; set; }

		[Display(Name = "EmailId")]
		[Required(ErrorMessage = "Please enter EmailId")]
		public string EmailId { get; set; }

		[Display(Name = "Start Date")]
		[Required(ErrorMessage = "Please enter Start Date")]
		public DateTime StartDate { get; set; }

		[Display(Name = "End Date")]
		[Required(ErrorMessage = "Please enter End Date")]
		public DateTime EndDate { get; set; }

		[Display(Name = "IsComputerized")]
		public bool IsComputerized { get; set; }

		[Display(Name = "Ownership Type")]
		[Required(ErrorMessage = "Please enter Ownership Type")]
		public short OwnershipTypeId { get; set; }

		public string OwnershipTypeName { get; set; }

		[Display(Name = "Data Entry Location")]
		[Required(ErrorMessage = "Please select DataEntry Location")]
		public string DataEntryLocation { get; set; }

		public string SavedDataEntryLocation { get; set; }

		[Display(Name = "Location Type")]
		[Required(ErrorMessage = "Please select Location Type")]
		public byte LocationType { get; set; }

		public string LocationTypeName { get; set; }

		[Display(Name = "Location Quality")]
		public string LocationQuality { get; set; }

		[Display(Name = "Length(cm)")]
		[Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
		public Decimal Length { get; set; }

		[Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
		[Display(Name = "Breadth(cm)")]
		public Decimal Breadth { get; set; }

		[Display(Name = "Height(cm)")]
		[Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
		public Decimal Height { get; set; }

		[Display(Name = "Area(sq.ft.)")]
		public Decimal Area { get; set; }

		public string rMessage { get; set; }
		[Display(Name = "Longitude")]
		public string Longitude { get; set; }

		[Display(Name = "Latitude")]
		public string Latitude { get; set; }

        [Display(Name = "Internal Location Code")]
        public string InternalLocationCode { get; set; }
	}
	public class LocationNameById
	{
        public short LocationId { get; set; }
        public string LocationName { get; set; }

    }
}
