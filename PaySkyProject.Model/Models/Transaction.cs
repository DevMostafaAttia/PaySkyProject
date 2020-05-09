using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paysky.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public long ProcessingCode { get; set; }
        public int SystemTraceNr { get; set; }
        public int FunctionCode { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public double AmountTrxn { get; set; }
        public int CurrencyCode { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public int ApprovalCode { get; set; }
        public DateTime DateTime { get; set; }
    }
}
