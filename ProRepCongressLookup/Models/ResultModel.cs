using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.Models
{
    [JsonConverter(typeof(DynamicPropertyNameConverter))]
    public class ResultModel<ModelType>
    {
        public string congress { get; set; }
        public string chamber { get; set; }
        public int num_results { get; set; }
        public int offset { get; set; }
        public string member_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
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
        public object rss_url { get; set; }
        public bool in_office { get; set; }
        public string current_party { get; set; }
        public string most_recent_vote { get; set; }
        public string last_updated { get; set; }
        [JsonPropertyNameByType("members", typeof(MemberModel))]
        [JsonPropertyNameByType("roles", typeof(RoleModel))]
        [JsonPropertyNameByType("Committees", typeof(CommitteeModel))]
        public List<ModelType> Models { get; set; }
    }
}
