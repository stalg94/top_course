using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense")]
        [Required]
        public string ExpenseNane { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than zero!")]
        public int CostAmount { get; set; }
        [DisplayName("Expense Type")]
        [ForeignKey("ExpenseTypeId")]
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }

    }
}
