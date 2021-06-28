using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrder.Models
{
    public class ItemModel
    {
        public int PO_ID { get; set; }
        public int PO_No { get; set; }
        public string PartyName { get; set; }
        public DateTime PO_Date { get; set; }
        public int PartyID { get; set; }
        public string Remarks { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscPercent { get; set; }
        public decimal Total { get; set; }
        public string Terms { get; set; }
        public string ItemName { get; set; }
        public int  ItemId { get; set; }
        public int DetailsID { get; set; }

        public List<ItemModel> ItemList { get; set; }
        public List<ItemModel> NameList { get; set; }
        public List<ItemModel> PartyList { get; set; }
        public List<ItemModel> PartyNameList { get; set; }
        public List<ItemModel> EditList { get; set; }

    }
}