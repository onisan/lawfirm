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
    
    public partial class NRBM_STAFF
    {
        public NRBM_STAFF()
        {
            this.NRBM_SETS = new HashSet<NRBM_SETS>();
            this.NRBM_WORKSFOR = new HashSet<NRBM_WORKSFOR>();
        }
    
        public int STAFFID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string TITLE { get; set; }
    
        public virtual ICollection<NRBM_SETS> NRBM_SETS { get; set; }
        public virtual ICollection<NRBM_WORKSFOR> NRBM_WORKSFOR { get; set; }
    }
}
