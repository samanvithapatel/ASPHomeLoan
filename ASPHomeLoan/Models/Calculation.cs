using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class Calculation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Required")]
        public double Salary { get; set; }
        public double ROI { get; set; }
        public double LoanTenure { get; set; }
        public double EMI { get; set; }
        public double LoanAmount { get; set; }
    }
}