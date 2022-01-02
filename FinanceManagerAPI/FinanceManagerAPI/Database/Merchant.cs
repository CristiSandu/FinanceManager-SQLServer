using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Table("Merchant")]
    public partial class Merchant
    {
        public Merchant()
        {
            TransactionAccs = new HashSet<TransactionAcc>();
        }

        [Key]
        [Column("merchant_id")]
        public int MerchantId { get; set; }
        [Column("merchant_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string MerchantName { get; set; } = null!;
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Column("merchant_description")]
        [StringLength(50)]
        [Unicode(false)]
        public string? MerchantDescription { get; set; }
        [Column("time_stamp", TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Merchants")]
        public virtual Category? Category { get; set; }
        [InverseProperty(nameof(TransactionAcc.Merchant))]
        public virtual ICollection<TransactionAcc> TransactionAccs { get; set; }
    }
}
