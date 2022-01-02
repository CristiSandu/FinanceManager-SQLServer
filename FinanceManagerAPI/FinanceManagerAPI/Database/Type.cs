using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    public partial class Type
    {
        public Type()
        {
            Accounts = new HashSet<Account>();
            Stats = new HashSet<Stat>();
            TransactionAccs = new HashSet<TransactionAcc>();
        }

        [Key]
        [Column("types_id")]
        public int TypesId { get; set; }
        [Column("types_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string TypesName { get; set; } = null!;
        [Column("table_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string? TableName { get; set; }

        [InverseProperty(nameof(Account.Types))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(Stat.Types))]
        public virtual ICollection<Stat> Stats { get; set; }
        [InverseProperty(nameof(TransactionAcc.Types))]
        public virtual ICollection<TransactionAcc> TransactionAccs { get; set; }
    }
}
