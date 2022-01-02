using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Merchants = new HashSet<Merchant>();
            TransactionAccs = new HashSet<TransactionAcc>();
        }

        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("category_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string CategoryName { get; set; } = null!;
        [Column("icon")]
        [StringLength(35)]
        [Unicode(false)]
        public string? Icon { get; set; }
        [Column("time_stamp", TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }

        [InverseProperty(nameof(Merchant.Category))]
        public virtual ICollection<Merchant> Merchants { get; set; }
        [InverseProperty(nameof(TransactionAcc.Category))]
        public virtual ICollection<TransactionAcc> TransactionAccs { get; set; }
    }
}
