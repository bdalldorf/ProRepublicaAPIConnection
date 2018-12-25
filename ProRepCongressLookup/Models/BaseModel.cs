using System;
using System.Collections.Generic;
using System.Text;

namespace ProRepCongressLookup.Models
{
    public class BaseModel<ModleType>
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public List<ResultModel<ModleType>> results { get; set; }
    }
}
