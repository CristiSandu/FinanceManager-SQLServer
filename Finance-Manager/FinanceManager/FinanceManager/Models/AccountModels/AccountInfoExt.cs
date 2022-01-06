using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models.AccountModels
{
    public class AccountInfoExt
    {
        [JsonProperty(PropertyName = "accountId")]
        public int AccountId { get; set; }
        [JsonProperty(PropertyName = "accountName")]
        public string AccountName { get; set; } 
        [JsonProperty(PropertyName = "typesId")]
        public int TypesId { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        [JsonProperty(PropertyName = "bankId")]
        public int BankId { get; set; }
        [JsonProperty(PropertyName = "bankName")]
        public string BankName { get; set; } 
        [JsonProperty(PropertyName = "accountBalance")]
        public double? AccountBalance { get; set; }
        [JsonProperty(PropertyName = "accountIban")]
        public string AccountIban { get; set; }
        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime? TimeStamp { get; set; }
        [JsonProperty(PropertyName = "accountHolder")]
        public string AccountHolder { get; set; }
    }
}
