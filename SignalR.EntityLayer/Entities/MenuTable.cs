﻿
namespace SignalR.EntityLayer.Entities
{
    public class MenuTable
    {
        public int MenuTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
