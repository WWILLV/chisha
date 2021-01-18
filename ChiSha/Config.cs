using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiSha
{
    class Config
    {
        public String dataPath { get; set; }
        public String pyPath { get; set; }
        public String getDataPath { get; set; }
    }
    class ConfigHandle
    {
        String path = "";
        String jsonStr = "";

        public ConfigHandle(string path)
        {
            this.path = path;
            if (!File.Exists(path))
            {
                Config c = new Config();
                c.dataPath = "";
                c.getDataPath = "";
                c.pyPath = "";
                setConfig(c);
            }
        }

        public Config getConfig()
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
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
            return JsonConvert.DeserializeObject<Config>(jsonStr);
        }
        public bool setConfig(Config c)
        {
            String config = JsonConvert.SerializeObject(c);
            StreamWriter sw = new StreamWriter(path);
            try
            {
                sw.WriteLine(config);
                sw.Flush();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
