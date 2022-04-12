using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class Loan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "MaxLoanGrantable")]
        [Required(ErrorMessage = "Required")]
        public double MaxLoanAmountGrantable { get; set; }
        [Required(ErrorMessage = "Required")]
        public double ROI { get; set; }
        [Required(ErrorMessage = "Required")]
        public double Tenure { get; set; }
        [Required(ErrorMessage = "Required")]
        public double LoanAmount { get; set; }
    }
}