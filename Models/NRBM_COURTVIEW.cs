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
    
    public partial class NRBM_COURTVIEW
    {
        public int CAID { get; set; }
        public int LAWID { get; set; }
        public int CLIENTID { get; set; }
        public int CASEID { get; set; }
        public string LFNAME { get; set; }
        public string LLNAME { get; set; }
        public string ALFNAME { get; set; }
        public string ALLNAME { get; set; }
        public string CFNAME { get; set; }
        public string CLNAME { get; set; }
        public Nullable<System.DateTime> COURTDATE { get; set; }
        public string RESULTS { get; set; }
    }
}
