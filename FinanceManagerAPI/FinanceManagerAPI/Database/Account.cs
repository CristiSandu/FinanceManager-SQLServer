using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Table("Account")]
    [Index(nameof(AccountIban), Name = "acc_iban_uk", IsUnique = true)]
    [Index(nameof(AccountName), Name = "acc_name_uk", IsUnique = true)]
    public partial class Account
    {
        public Account()
        {
            Stats = new HashSet<Stat>();
            TransactionAccs = new HashSet<TransactionAcc>();
        }

        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }
        [Column("account_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string AccountName { get; set; } = null!;
        [Column("types_id")]
        public int? TypesId { get; set; }
        [Column("bank_id")]
        public int? BankId { get; set; }
        [Column("account_balance")]
        public double? AccountBalance { get; set; }
        [Column("account_IBAN")]
        [StringLength(50)]
        [Unicode(false)]
        public string? AccountIban { get; set; }
        [Column("time_stamp", TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }
        [Column("account_holder")]
        [StringLength(50)]
        [Unicode(false)]
        public string? AccountHolder { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty("Accounts")]
        public virtual Bank? Bank { get; set; }
        [ForeignKey(nameof(TypesId))]
        [InverseProperty(nameof(Type.Accounts))]
        public virtual Type? Types { get; set; }
        [InverseProperty(nameof(Stat.Account))]
        public virtual ICollection<Stat> Stats { get; set; }
        [InverseProperty(nameof(TransactionAcc.Account))]
        public virtual ICollection<TransactionAcc> TransactionAccs { get; set; }
    }
}
