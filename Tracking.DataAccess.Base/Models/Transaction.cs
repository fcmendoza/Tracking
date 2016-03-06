using System;
using System.Collections.Generic;

namespace Tracking.DataAccess.Base.Models {
    public class Transaction { 
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public IList<String> Tags { get; set; }
        public string AccountName { get; set; }
    }
}
