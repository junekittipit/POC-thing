using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace other
{
    class Program
    {
        void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                List<model> items = JsonConvert.DeserializeObject<List<model>>(json);
            }
        }

        public class model
        {
            public string _id { get; set; }
            public stateinfo StateInfo { get; set; }
        }

        public class stateinfo
        {
            public Dictionary<string, object> Report { get; set; }
        }
    }
}
