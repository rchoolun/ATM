//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NVisonIT.AutomatedTellerMachine.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }
    
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int CardId { get; set; }
        public int AccountTypeId { get; set; }
        public int AmountAvailable { get; set; }
    
        public virtual AccountType AccountType { get; set; }
        public virtual Card Card { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
