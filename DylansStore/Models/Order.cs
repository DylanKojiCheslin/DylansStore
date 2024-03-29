//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DylansStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }
    
        public int OrderID { get; set; }
        public Nullable<int> ShippingAddressID { get; set; }
        public Nullable<int> BillingAddressID { get; set; }
        public Nullable<int> ShippingID { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SalesTax { get; set; }
        public decimal SubTotal { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> DateShiped { get; set; }
        public Nullable<System.DateTime> DateCompleated { get; set; }
        public decimal ShippingCost { get; set; }
        public string Status { get; set; }
    
        public virtual Address ShippingAddress { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
