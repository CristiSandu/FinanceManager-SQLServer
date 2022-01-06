using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Keyless]
    [Table("TransactionInfoExt")]
    public partial class TransactionInfoExt
    {
        [Column("transaction_id")]
        public int TransactionId { get; set; }
        [Column("transaction_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string TransactionName { get; set; } = null!;
        [StringLength(35)]
        [Unicode(false)]
        public string? TypeIcon { get; set; }
        [Column("merchant_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string MerchantName { get; set; } = null!;
        [Column("category_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string CategoryName { get; set; } = null!;
        [StringLength(35)]
        [Unicode(false)]
        public string? CategoryIcon { get; set; }
        [Column("color")]
        [StringLength(35)]
        [Unicode(false)]
        public string? Color { get; set; }
        [Column("transaction_price")]
        public double TransactionPrice { get; set; }
        [Column("transaction_Date", TypeName = "date")]
        public DateTime TransactionDate { get; set; }
        [Column("image")]
        [MaxLength(50)]
        public byte[]? Image { get; set; }
        [Column("transaction_description")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TransactionDescription { get; set; }
        [Column("time_stamp", TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }
    }
}
