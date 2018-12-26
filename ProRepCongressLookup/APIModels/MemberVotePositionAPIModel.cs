using ProRepCongressLookup.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.APIModels
{
    public class MemberVotePositionAPIModel
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public List<Result> results { get; set; }

        public class Result
        {
            public string member_id { get; set; }
            public string num_results { get; set; }
            public string offset { get; set; }
            public List<VoteModel> votes { get; set; }
        }
    }
}
