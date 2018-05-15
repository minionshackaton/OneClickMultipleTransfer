using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneClickMultipleTransfer.Models
{
    public class TransferDetails
    {
        public string AccountNumber { get; set; }      
        public string TransferAmount { get; set; }
        public string PayeeName { get; set; }
        public string TransferStatus { get; set; }
    }
}