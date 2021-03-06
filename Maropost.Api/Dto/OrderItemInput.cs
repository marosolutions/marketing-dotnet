﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Maropost.Api.Dto
{
    public class OrderItemInput
    {
        public OrderItemInput(int itemId, decimal price, decimal quantity, string description, string adcode, string category)
        {
            item_id = itemId.ToString();
            this.price = price.ToString();
            this.quantity = quantity.ToString();
            this.description = description;
            this.adcode = adcode;
            this.category = category;
        }
        public string item_id { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string description { get; set; }
        public string adcode { get; set; }
        public string category { get; set; }
    }
}