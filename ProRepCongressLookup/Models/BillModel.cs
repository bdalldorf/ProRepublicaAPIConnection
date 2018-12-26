using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.Models
{
    public class BillModel
    {
        public string bill_id { get; set; }
        public string number { get; set; }
        public string sponsor_id { get; set; }
        public string bill_uri { get; set; }
        public string title { get; set; }
        public string latest_action { get; set; }
        public object api_uri { get; set; }
    }
}
