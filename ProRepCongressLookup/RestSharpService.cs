using Newtonsoft.Json;
using ProRepCongressLookup.Models;
using System.Linq;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Collections.Generic;
using System.IO;

namespace ProRepCongressLookup
{
    public class RestSharpService : ISerializer, IDeserializer
    {
        private Newtonsoft.Json.JsonSerializer _Serializer;

        public RestSharpService(Newtonsoft.Json.JsonSerializer serializer)
        {
            this._Serializer = serializer;
        }

        public string ContentType
        {
            get { return "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8"; }
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    _Serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        public ModelType Deserialize<ModelType>(RestSharp.IRestResponse response)
        {
            var Content = response.Content;

            using (var stringReader = new StringReader(Content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _Serializer.Deserialize<ModelType>(jsonTextReader);
                }
            }
        }

        public static RestSharpService Default
        {
            get
            {
                return new RestSharpService(new Newtonsoft.Json.JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
        }
    }
}