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
        public int CASEID { get; set; }
        public int CLIENTID { get; set; }
        public Nullable<System.DateTime> SDATE { get; set; }
        public Nullable<System.DateTime> EDATE { get; set; }
        public string EVIDENCE { get; set; }
        public string CATEGORY { get; set; }
        public string LITIGATION { get; set; }
        public string NOTES { get; set; }
    }
}
