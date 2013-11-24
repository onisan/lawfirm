using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLawFirm.Models
{
    public class LawyerReport : NRBM_LAWYER
    {
        public decimal Earnings { get; set; }
        public decimal Expenses { get; set; }
        public int Appointments { get; set; }
        public int CourtAppearances { get; set; }
        public int Cases { get; set; }
        public int Clients { get; set; }
    }
}