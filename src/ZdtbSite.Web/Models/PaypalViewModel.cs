using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Models
{
    public class PaypalViewModel
    {
        public PaypalViewModel(string business, string item_name, decimal amount, string notify_url, string action, string currency_code = "USD")
        {
            this.business = business;
            this.item_name = item_name;
            this.amount = amount;
            this.notify_url = notify_url;
            this.Action = action;
            this.currency_code = currency_code;
        }
        public string business { get; set; }

        public string item_name { get; set; }

        public decimal amount { get; set; }

        public string currency_code { get; set; }

        public string notify_url { get; set; }

        public string Action { get; set; }

    }
}