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
    
    public partial class NRBM_APPOINTMENT
    {
        public int APTID { get; set; }
        public int LAWID { get; set; }
        public int CASEID { get; set; }
        public int CLIENTID { get; set; }
        public Nullable<System.DateTime> DATEON { get; set; }
        public string LOCATION { get; set; }
        public string DESCRIPTION { get; set; }
    }
}