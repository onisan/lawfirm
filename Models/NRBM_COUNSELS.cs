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
    
    public partial class NRBM_COUNSELS
    {
        public int COUNSELSID { get; set; }
        public Nullable<int> LAWID { get; set; }
        public Nullable<int> CLIENTID { get; set; }
        public Nullable<System.DateTime> SDATE { get; set; }
        public Nullable<System.DateTime> EDATE { get; set; }
        public Nullable<decimal> HOURS { get; set; }
        public Nullable<decimal> FEES { get; set; }
    
        public virtual NRBM_CLIENT NRBM_CLIENT { get; set; }
        public virtual NRBM_LAWYER NRBM_LAWYER { get; set; }
    }
}
