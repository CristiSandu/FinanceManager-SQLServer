using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Keyless]
    [Table("AccountInfoExt")]
    public partial class AccountInfoExt
    {
        [Column("account_id")]
        public int AccountId { get; set; }
        [Column("account_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string AccountName { get; set; } = null!;
        [Column("types_id")]
        public int? TypesId { get; set; }
        [Column("icon")]
        [StringLength(35)]
        [Unicode(false)]
        public string? Icon { get; set; }
        [Column("bank_id")]
        public int? BankId { get; set; }
        [Column("bank_name")]
        [StringLength(35)]
        [Unicode(false)]
        public string BankName { get; set; } = null!;
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
    }
}
