//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLogic.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public Nullable<int> VendorId { get; set; }
        public string Description { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> SubCategoryId { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Barcode { get; set; }
        public string Alias { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual Inventory Inventory1 { get; set; }
        public virtual Inventory Inventory2 { get; set; }
    }
}
