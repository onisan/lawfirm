﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLawFirm.Models
{
    public class LawyerReport
    {
        public int LAWID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string POSITION { get; set; }
        public string FullName { get { return FNAME + " " + LNAME; } set { FNAME = FNAME; } }
        public decimal Earnings { get; set; }
        public decimal Expenses { get; set; }
        public int Appointments { get; set; }
        public int CourtAppearances { get; set; }
        public int Cases { get; set; }
        public int Clients { get; set; }
        
        public virtual ICollection<NRBM_APPOINTMENT> NRBM_APPOINTMENT { get; set; }
        public virtual ICollection<NRBM_COUNSELS> NRBM_COUNSELS { get; set; }
        public virtual ICollection<NRBM_COURTAPPEARANCE> NRBM_COURTAPPEARANCE { get; set; }
        public virtual ICollection<NRBM_WORKSFOR> NRBM_WORKSFOR { get; set; }
    }
}