using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Table("Bank")]
    public partial class Bank
    {
        public Bank()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("bank_id")]
        public int BankId { get; set; }
        [Column("bank_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string BankName { get; set; } = null!;
        [Column("bank_description")]
        [StringLength(50)]
        [Unicode(false)]
        public string? BankDescription { get; set; }
        [Column("image")]
        [MaxLength(50)]
        public byte[]? Image { get; set; }
        [Column("time_stamp", TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }

        [InverseProperty(nameof(Account.Bank))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
