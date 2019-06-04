using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace WhiteCoat.Utils
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }

    public class JsonContent<T> : StringContent
    {
        public JsonContent(T obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }
}
