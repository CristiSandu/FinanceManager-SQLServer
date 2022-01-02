using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Database
{
    public partial class Stat
    {
        [Key]
        [Column("stats_id")]
        public int StatsId { get; set; }
        [Column("stats_date", TypeName = "date")]
        public DateTime StatsDate { get; set; }
        [Column("types_id")]
        public int? TypesId { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }
        [Column("incomes")]
        public double? Incomes { get; set; }
        [Column("expences")]
        public double? Expences { get; set; }
        [Column("time_stamp", TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Stats")]
        public virtual Account? Account { get; set; }
        [ForeignKey(nameof(TypesId))]
        [InverseProperty(nameof(Type.Stats))]
        public virtual Type? Types { get; set; }
    }
}
