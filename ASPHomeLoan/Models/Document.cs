using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte[] PanCard { get; set; }
        public byte[] VoterId { get; set; }
        public byte[] SalarySlip { get; set; }
        public byte[] LOA { get; set; }
        public byte[] NOCFromBuilder { get; set; }
        public byte[] AgreementToSale { get; set; }
    }
}