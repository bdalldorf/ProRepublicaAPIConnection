using Newtonsoft.Json;
using System.Reactive;
using System.Collections.Generic;
using ProRepCongressLookup.Models;

namespace ProRepCongressLookup.APIModels
{
    public class ListOfMembersAPIModel
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public List<Result> results { get; set; }

        public class Result
        {
            public string congress { get; set; }
            public string chamber { get; set; }
            public int num_results { get; set; }
            public int offset { get; set; }
            public List<MemberModel> members { get; set; }
        }
    }
}
