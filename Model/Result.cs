using Newtonsoft.Json;
using System;

namespace MarvelApi.Model
{
    public class Result
    {
        public string id { get; set; }

        [JsonProperty("title")]
        public string name { get; set; }

        public string description { get; set; }

        public Comics comics { get; set; }

        public Series series { get; set; }

        public Stories stories { get; set; }

        public Events events{ get; set; }
    }
}
