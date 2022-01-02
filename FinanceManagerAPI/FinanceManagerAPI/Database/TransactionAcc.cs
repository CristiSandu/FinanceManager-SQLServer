using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Table("Transaction_Acc")]
    public partial class TransactionAcc
    {
        [Key]
        [Column("transaction_id")]
        public int TransactionId { get; set; }
        [Column("transaction_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string TransactionName { get; set; } = null!;
        [Column("types_id")]
        public int? TypesId { get; set; }
        [Column("merchant_id")]
        public int? MerchantId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
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

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("TransactionAccs")]
        public virtual Account? Account { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("TransactionAccs")]
        public virtual Category? Category { get; set; }
        [ForeignKey(nameof(MerchantId))]
        [InverseProperty("TransactionAccs")]
        public virtual Merchant? Merchant { get; set; }
        [ForeignKey(nameof(TypesId))]
        [InverseProperty(nameof(Type.TransactionAccs))]
        public virtual Type? Types { get; set; }
    }
}
