 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class SignIn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public int Id { get; set; }
        [Required(ErrorMessage = "User name Required")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string UserEmailId { get; set; }
        [Required(ErrorMessage = "Required password")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}