using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class Personal
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string EmailId { get; set; }
        public int PhoneNumber { get; set; }
        
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Provide Nationality")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Please Provide AadharNumber")]
        public double AadharNumber { get; set; }
        [Required(ErrorMessage = "Please Provide PanNumber")]
        public double PanNumber { get; set; }


    }
}