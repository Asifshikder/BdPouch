using System;
using System.ComponentModel.DataAnnotations;

namespace BdPouch.Core
{
    public class BaseEntity
    {
        public long Id { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Updated On")]
        public DateTime? UpdatedOn { get; set; }
    }
}
