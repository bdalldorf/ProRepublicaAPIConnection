using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.Models
{
    [JsonConverter(typeof(DynamicPropertyNameConverter))]
    public class ResultModel<ModelType>
    {
        [JsonPropertyNameByResult("congress")]
        public string Congress { get; set; }
        [JsonPropertyNameByResult("chamber")]
        public string Chamber { get; set; }
        [JsonPropertyNameByResult("num_results")]
        public int Num_results { get; set; }
        [JsonPropertyNameByResult("offset")]
        public int Offset { get; set; }
        [JsonPropertyNameByType("members", typeof(MemberModel))]
        public List<ModelType> Models { get; set; }
    }
}
