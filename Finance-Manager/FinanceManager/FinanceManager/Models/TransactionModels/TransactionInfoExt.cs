using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FinanceManager.Models.TransactionModels
{
    public class TransactionInfoExt
    {
        [JsonProperty(PropertyName = "transactionId")]
        public int TransactionId { get; set; }

        [JsonProperty(PropertyName = "transactionName")]
        public string TransactionName { get; set; }

        [JsonProperty(PropertyName = "typeIcon")]
        public string TypeIcon { get; set; }

        [JsonProperty(PropertyName = "merchantName")]
        public string MerchantName { get; set; } 
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }
        [JsonProperty(PropertyName = "categoryIcon")]
        public string CategoryIcon { get; set; }
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
        [JsonProperty(PropertyName = "transactionPrice")]
        public double TransactionPrice { get; set; }
        [JsonProperty(PropertyName = "transactionDate")]
        public DateTime TransactionDate { get; set; }
        [JsonProperty(PropertyName = "image")]
        public byte[] Image { get; set; }
        [JsonProperty(PropertyName = "transactionDescription")]
        public string TransactionDescription { get; set; }
        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }


        public Color ColorCategory => Xamarin.Forms.Color.FromHex(Color);
        public Color ArrowColor => TypeIcon == "arrow-up" ? Xamarin.Forms.Color.Green : Xamarin.Forms.Color.Red;

        public double ShowPrice => TypeIcon == "arrow-up" ?  TransactionPrice : TransactionPrice * -1;


    }
}
