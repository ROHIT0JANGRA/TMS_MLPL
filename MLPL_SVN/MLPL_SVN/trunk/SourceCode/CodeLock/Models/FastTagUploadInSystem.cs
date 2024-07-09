using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class FastTagUploadInSystem : Response
    {
        public string FileName { get; set; }

        public HttpPostedFileBase File { get; set; }

        public short EntryBy { get; set; }

        [Display(Name = "Tripsheet")]
        [Required(ErrorMessage = "Please select Tripsheet")]
        public string TripsheetId { get; set; }

        public FastTagUploadInSystem()
        {
            this.Details = new List<FastTag>();
        }

        public List<FastTag> Details { get; set; }

    }
}