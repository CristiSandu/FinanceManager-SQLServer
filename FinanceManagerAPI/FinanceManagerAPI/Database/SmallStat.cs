using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    [Keyless]
    public partial class SmallStat
    {
        [Column("total_balance", TypeName = "decimal(7, 2)")]
        public decimal? TotalBalance { get; set; }
        [Column("number_expences")]
        public int? NumberExpences { get; set; }
        [Column("number_incoms")]
        public int? NumberIncoms { get; set; }
        [Column("number_cards")]
        public int? NumberCards { get; set; }
        [Column("number_banks")]
        public int? NumberBanks { get; set; }
    }
}
