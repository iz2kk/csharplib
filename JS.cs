using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace JSCNSercurity
{
    public static class JS
    {
        public static List<JObject> extract(string jsonInput)
        {
            if (jsonInput.isNull()) return null;
            var json = JsonConvert.DeserializeObject<List<JObject>>(jsonInput);
            return json;
        }

        public static List<JObject> ToExtract(this string jsonInput)
        {
            if (jsonInput.isNull()) return null;
            var json = JsonConvert.DeserializeObject<List<JObject>>(jsonInput);
            return json;
        }

        public static string getThumb(string json)
        {
            if (json.isNull()) return "N/A.png";

            var js = json.ToExtract();
            if(js.Count <= 0) return "N/A.png";


            var img = js[0];

            if (img.ContainsKey("id") && img.ContainsKey("image") && img.ContainsKey("file"))
            {
                return img["image"].Value<string>();
            }
            return "N/A.png";
        }

    }
}