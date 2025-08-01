﻿using SignalR.EntityLayer.Entities;

namespace SSignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description  { get; set; }
        public decimal Price  { get; set; }
        public string ImageUrl  { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
		//CategoryID: Ürünün hangi kategoriye ait olduğunu belirten anahtar(foreign key).
		//Category: O kategoriye ait bilgilere erişmeni sağlayan nesne(navigasyon properti).
		public List<OrderDetail> OrderDetails { get; set; }
        public List<Basket> baskets { get; set; }
    }
}
