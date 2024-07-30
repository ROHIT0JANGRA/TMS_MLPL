//  
// Type: CodeLock.Models.MasterUser
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Models
{
    public class MasterUser : BaseModel
    {
        [Display(Name = "User")]
        public short UserId { get; set; }

        [StringLength(50, ErrorMessage = "User Name must be minimum 5 and maximum 50 character long", MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter User Name")]
        [Display(Name = "User Name")]
        [Remote("IsUserNameAvailable", "User", AdditionalFields = "UserId,_UserIdToken", ErrorMessage = "User Name already exists.", HttpMethod = "POST")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Password must be minimum 6 and maximum 25 character long", MinimumLength = 6)]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please select Location")]
        public short LocationId { get; set; }

        [StringLength(100, ErrorMessage = "Name must be minimum 5 and maximum 50 character long", MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Display(Name = "Mobile No")]
        [MobileAnnotation]
        public string MobileNo { get; set; }

        [EmailAnnotation]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select Date Of Birth")]
        [Display(Name = "Date Of Birth")]
        public DateTime DoB { get; set; }

        [Required(ErrorMessage = "Please select Date Of Joininig")]
        [Display(Name = "Date Of Joininig")]
        [DataType(DataType.DateTime)]
        public DateTime DoJ { get; set; }

        [Display(Name = "Address")]
        [StringLength(300, ErrorMessage = "Address must be minimum 2 and maximum 300 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Photo")]
        public HttpPostedFileBase PhotoAttachment { get; set; }

        [Display(Name = "User Status")]
        [Required(ErrorMessage = "Please select User Status")]
        public bool UserStatusId { get; set; }

        [Display(Name = "User Type")]
        [Required(ErrorMessage = "Please select User Type")]
        public string UserTypeId { get; set; }

        [Display(Name = "Default Company")]
        public byte? DefaultCompanyId { get; set; }

        public string DefaultCompanyCode { get; set; }

        public string DefaultCompanyName { get; set; }

        [Display(Name = "Default Warehouse")]
        public short? DefaultWarehouseId { get; set; }

        public string DefaultWarehouseName { get; set; }

        public long ManagerId { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }

        [Display(Name = "Location Code")]
        public string LocationCode { get; set; }

        public string UserStatus { get; set; }

        public string UserType { get; set; }

        [Required(ErrorMessage = "Please select Role")]
        [Display(Name = "Role")]
        public byte RoleId { get; set; }

        public string RoleName { get; set; }

        public string WarehouseName { get; set; }

        [Display(Name = "User Type Map Code")]
        public string UserTypeMapCode { get; set; }

        public string UserTypeMapName { get; set; }

        public short? UserTypeMapId { get; set; }

        public DateTime? CompanyStartDate { get; set; }

        public short LocationHierarchyId { get; set; }

        [Display(Name = "User Company")]
        [Required(ErrorMessage = "Please select At-least one thing")]
        public string UserCompany { get; set; }
        public string SavedUserCompany { get; set; }
    }
    public class MasterUserDetail
    {
        public short UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte CompanyId { get; set; }
        public short UserTypeMapId { get; set; }
        public short LocationId { get; set; }
        public string LocationCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string CompanyName { get; set; }
        //
    }
    public class ApiLoginRequest
    {
        public short UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string LocationCode { get; set; }
        public string DefaultCompanyName { get; set; }
        public string RoleName { get; set; }
    }
    public class ApiLoginResultResponse
    {
        public bool Flag { get; set; }
        public string FlagMessage { get; set; }
        public ApiLoginResponseData Data { get; set; }
    }

    public class ApiLoginResponseData
    {
        public short UserId { get; set; }
        public string UserName { get; set; }
        public string LocationCode { get; set; }
        public string CompanyName { get; set; }
        public string UserRole { get; set; }
    }

    //MasterUser
    public class User
    {
        public string API_USER { get; set; }
        public string API_PASSWORD { get; set; }
        public string GstTinNo { get; set; }
        public short StateId { get; set; }
        public short LoginLocationId { get; set; }
        public short locationId { get; set; }

    }
}