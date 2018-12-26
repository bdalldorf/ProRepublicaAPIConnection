using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.Models
{
    public class VoteModel
    {
        public string member_id { get; set; }
        public string chamber { get; set; }
        public string congress { get; set; }
        public string session { get; set; }
        public string roll_call { get; set; }
        public string vote_uri { get; set; }
        public BillModel bill { get; set; }
        public AmendmentModel amendment { get; set; }
        public string description { get; set; }
        public string question { get; set; }
        public string result { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public TotalModel total { get; set; }
        public string position { get; set; }
    }
}
