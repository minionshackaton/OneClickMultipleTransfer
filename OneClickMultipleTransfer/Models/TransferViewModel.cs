using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneClickMultipleTransfer.Models
{
    public class TransferViewModel
    {
        public string AccountNumber { get; set; }
        public List<Payee> PayeeDetails { get; set; }
        public List<Payee> PayeeList { get; set; }
        public List<TransferDetails> TransferDetailsList { get; set; }
    }
}