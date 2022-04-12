using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
   
    public class IncomeDetails
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Required(ErrorMessage = "Required")]
        public int ApplicationId { get; set; }
        [Required(ErrorMessage ="Required")]
        [Display(Name = "ProperityLocation")]
        public string ProperityLocation { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ProperityName { get; set; } 
        [Required(ErrorMessage = "Required")]
        public double EstimatedAmount { get; set; }
        [Required(ErrorMessage = "Required")]
        public string TypeOfEmployeement { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Retirement Age")]
        [Range(60, 70, ErrorMessage = "Age Should be min 60 and max 70")]
        public int ? RetirementAge { get; set; }
        [Required(ErrorMessage = "Required")]
        public string OrganizationType { get; set; }
        [Required(ErrorMessage = "Required")]
        public string EmployeeName { get; set; }
    }
}