using System;
using System.Collections.Generic;
using System.Text;

namespace paysky.Model
{
    public class TransactionViewModel
    {
        public long ProcessingCode { get; set; }
        public int SystemTraceNr { get; set; }
        public int FunctionCode { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public double AmountTrxn { get; set; }
        public int CurrencyCode { get; set; }

    }
}
