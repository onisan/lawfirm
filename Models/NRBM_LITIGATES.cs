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
    
    public partial class NRBM_LITIGATES
    {
        public int LITID { get; set; }
        public Nullable<int> ADLAWID { get; set; }
        public Nullable<int> CASEID { get; set; }
        public Nullable<System.DateTime> SDATE { get; set; }
        public Nullable<System.DateTime> EDATE { get; set; }
        public string RESULTS { get; set; }
    
        public virtual NRBM_ADVERSELAWYER NRBM_ADVERSELAWYER { get; set; }
        public virtual NRBM_CASE NRBM_CASE { get; set; }
    }
}
