using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.Models
{
    public class BaseModel<ModleType>
    {
        [JsonPropertyNameByBase("status")]
        public string Status { get; set; }
        [JsonPropertyNameByBase("copyright")]
        public string Copyright { get; set; }
        [JsonPropertyNameByBase("results")]
        public List<ResultModel<ModleType>> Results { get; set; }
    }
}
