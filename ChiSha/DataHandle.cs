using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChiSha
{
    class Data
    {
        public String title { get; set; }
        public Dictionary<String, String> ins { get; set; }
        public List<Dictionary<String, String>> steps { get; set; }
        public String url { get; set; }

        public Data(string title, Dictionary<string, string> ins, List<Dictionary<string, string>> steps, string url)
        {
            this.title = title;
            this.ins = ins;
            this.steps = steps;
            this.url = url;
        }
    }
    class DataHandle
    {
        String jsonPath = "";
        String jsonStr = "";

        public DataHandle(string jsonPath)
        {
            this.jsonPath = jsonPath;
            this.jsonStr = getJson();
        }

        public String getJson()
        {
            StreamReader sr = new StreamReader(jsonPath, Encoding.UTF8);
            try
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    jsonStr += line.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                sr.Close();
            }
            return jsonStr;
        }

        public List<Data> getData()
        {
            return JsonConvert.DeserializeObject<List<Data>>(jsonStr);
        }
    }
}
