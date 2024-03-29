//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcLawFirm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NRBM_CASE
    {
        public NRBM_CASE()
        {
            this.NRBM_APPOINTMENT = new HashSet<NRBM_APPOINTMENT>();
            this.NRBM_COURTAPPEARANCE = new HashSet<NRBM_COURTAPPEARANCE>();
            this.NRBM_LITIGATES = new HashSet<NRBM_LITIGATES>();
        }
    
        public int CASEID { get; set; }
        public Nullable<int> CLIENTID { get; set; }
        public Nullable<System.DateTime> SDATE { get; set; }
        public Nullable<System.DateTime> EDATE { get; set; }
        public string EVIDENCE { get; set; }
        public string CATEGORY { get; set; }
        public string LITIGATION { get; set; }
        public string NOTES { get; set; }
    
        public virtual ICollection<NRBM_APPOINTMENT> NRBM_APPOINTMENT { get; set; }
        public virtual NRBM_CLIENT NRBM_CLIENT { get; set; }
        public virtual ICollection<NRBM_COURTAPPEARANCE> NRBM_COURTAPPEARANCE { get; set; }
        public virtual ICollection<NRBM_LITIGATES> NRBM_LITIGATES { get; set; }
    }
}
