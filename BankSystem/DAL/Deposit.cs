//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deposit
    {
        public Deposit()
        {
            this.Transaction = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public decimal Balance { get; set; }
        public int DepositTypeId { get; set; }
        public Nullable<int> RequestId { get; set; }
        public System.DateTime EndDate { get; set; }
    
        public virtual DepositType DepositType { get; set; }
        public virtual Request Request { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
