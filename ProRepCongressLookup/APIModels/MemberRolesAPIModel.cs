using ProRepCongressLookup.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.APIModels
{
    public class MemberRolesAPIModel
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public List<Result> results { get; set; }

        public class Result
        {
            public string member_id { get; set; }
            public string first_name { get; set; }
            public object middle_name { get; set; }
            public string last_name { get; set; }
            public object suffix { get; set; }
            public string date_of_birth { get; set; }
            public string gender { get; set; }
            public string url { get; set; }
            public string times_topics_url { get; set; }
            public string times_tag { get; set; }
            public string govtrack_id { get; set; }
            public string cspan_id { get; set; }
            public string votesmart_id { get; set; }
            public string icpsr_id { get; set; }
            public string twitter_account { get; set; }
            public string facebook_account { get; set; }
            public object youtube_account { get; set; }
            public string crp_id { get; set; }
            public string google_entity_id { get; set; }
            public string rss_url { get; set; }
            public bool in_office { get; set; }
            public string current_party { get; set; }
            public string most_recent_vote { get; set; }
            public string last_updated { get; set; }
            public List<RoleModel> roles { get; set; }
        }
    }
}
