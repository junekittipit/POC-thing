using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace POC_thing
{
    class Program
    {

        static async Task Main(string[] args)
        {
            modeltest test = new modeltest();
            var request =  new { doub = 0.0, set = 1,zeropoint=0.00 ,morethanfive = 5.89 ,innzero = 0,lonnnnglength=5.00 ,infi=1.00};
            foreach (var item in request.GetType().GetProperties())
            {
                var value = request.GetType().GetProperty(item.Name).GetValue(request, null);
                if (value is double)
                {
                    int tempvalue = (int)Math.Truncate(decimal.Parse(value.ToString()));

                    double purevalue = double.Parse(value.ToString());
                    double resultmod = 0.00;
                    if (tempvalue != 0)
                    {
                        resultmod = purevalue % tempvalue;
                    }

                    if (resultmod != 0)
                    {
                        Console.WriteLine($"Type of {item.Name} is { item.PropertyType} value is {value} stay in double {purevalue}");
                    }
                    else {
                        Console.WriteLine($"Type of {item.Name} is { item.PropertyType} value is {value} convert to int {tempvalue}");
                    }   
                }
                Console.WriteLine($"Type of {item.Name} is { item.PropertyType} value is {value}");
            }
            //Console.WriteLine($"Type of doub{}");
            Console.WriteLine(JsonConvert.SerializeObject(request));
            Console.WriteLine(JsonConvert.SerializeObject(request));

            Dictionary<string, object> collection = new Dictionary<string, object>() { { "lastActivityTime", 1645460640280.0 } };
            foreach (var item in collection)
            {
                parseeeee(item);
            }
            

            //List<prirorityinfo> prirorityinfos = new List<prirorityinfo>()
            //{
            // new prirorityinfo(){PrirorityLevel = 0 ,PrirorityKey = "Environment" },
            // new prirorityinfo(){PrirorityLevel = 1 ,PrirorityKey = "Customer" },
            // new prirorityinfo(){PrirorityLevel = 2 ,PrirorityKey = "Tenant" },
            // new prirorityinfo(){PrirorityLevel = 3 ,PrirorityKey = "Account" },
            // new prirorityinfo(){PrirorityLevel = 4 ,PrirorityKey = "Thing" },
            // new prirorityinfo(){PrirorityLevel = 4.1 ,PrirorityKey = "Destination" }
            //};

            //var dict = new Dictionary<string, string>();
            //dict.Add("TRANSSIZE_KBYTES", "50");

            //var dict1 = new Dictionary<string, string>();
            //dict1.Add("TRANSSIZE_KBYTES", "100");
            //List<limitation> resultDb = new List<limitation>() {
            //new limitation(){ key = "Account",limitationdetail= dict },
            // new limitation(){ key = "Thing",limitationdetail= dict },
            // new limitation(){ key = "Tenant",limitationdetail= dict1 },
            //};
            //List<double> test = new List<double>() { 1.2, 1.1, 4.5, 3.3 };
            //var teeee = prirorityinfos.OrderByDescending(x => x.PrirorityLevel).ToList();
            //foreach (var item in teeee)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //}




            //Console.WriteLine(Getmaxvalue(test));
            //foreach (var limitationinfo in resultDb)
            //{
            //    foreach (var prirority in prirorityinfos)
            //    {
            //        if (limitationinfo.key == prirority.PrirorityKey)
            //        {
            //            Console.WriteLine(JsonConvert.SerializeObject(limitationinfo));
            //        }
            //    }               
            //}
            //for (int i = 0; i <= resultDb.Count; i++)
            //{
            //    var temp = prirorityinfos.OrderByDescending(x => x.PrirorityLevel).FirstOrDefault();
            //    var resultresponse = resultDb.Where(x => x.key == temp.PrirorityKey).FirstOrDefault();
            //    Console.WriteLine(JsonConvert.SerializeObject(resultresponse));
            //    prirorityinfos.Remove(temp);
            //}

            string result = string.Empty;
            //try
            //{
            //    List<string> infos = new List<string>();
            //    infos.Add("[info] <0.30633.509> accepting MQTT connection <0.30633.509> (10.0.126.0:4277 -> 10.0.112.108:1883, client id: tunwatestlogin222)");
            //    infos.Add("[info] <0.20565.506> accepting MQTT connection <0.20565.506> (10.0.126.0:25908 -> 10.0.113.219:1883, client id: tunwatestlogin222)");
            //    infos.Add("[info] <0.16040.510> accepting MQTT connection <0.16040.510> (10.0.107.0:54059 -> 10.0.112.108:1883, client id: tunwatestlogin222)");
            //    string pattern = @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}):(\d{1,5}) -> (\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}):(\d{1,5})";


            //    Console.WriteLine(infos);
            //    foreach (var info in infos)
            //    {
            //        var infoLower = info.ToLower();
            //        if (Regex.Match(infoLower, @"closing").Success)
            //        {
            //            result = infoLower.Substring(infoLower.IndexOf("(") + 1);
            //            result = result.Remove(result.IndexOf(")"));
            //        }
            //        else if (Regex.Match(info, @"accepting MQTT connection").Success)
            //        {
            //            var resultregex = Regex.Match(info, pattern);
            //            result = resultregex.ToString();
            //        }
            //        else if (Regex.Match(infoLower, @"terminating").Success)
            //        {
            //            result = infoLower.Substring(infoLower.IndexOf("port") + 10);
            //            result = result.Remove(result.IndexOf("\""));
            //        }
            //        Console.WriteLine("result => {0} ", result);

            //        if (!String.IsNullOrEmpty(result))
            //        {
            //            var rabbitmqresponse = string.Empty;
            //            //List<string> list = new List<string>();
            //            //list.Add(result);
            //            //List<int> integerList = Enumerable.Range(0, list.Count()).ToList();
            //            //var options = new ParallelOptions() { MaxDegreeOfParallelism = 4 };
            //            await Task.Run(async () =>
            //            {
            //                await Task.Delay(2000);
            //                Console.WriteLine("Send to Rabbit API");
            //            });
            //            JObject objresp = JObject.Parse(rabbitmqresponse);
            //            string error = (string)objresp["error"];
            //            if (error != null)
            //            {
            //                await Task.Run(async () =>
            //                {
            //                    await Task.Delay(1000);
            //                    Console.WriteLine("Send to Rabbit API");
            //                });
            //            }
            //            Console.WriteLine(rabbitmqresponse);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}

            Console.WriteLine("Hello World!");
        }

        private static double Getmaxvalue(List<double> so)
        {
            return so.Max();
        }

        private static string parseeeee(KeyValuePair<string, object> sensor)
        {
            string type = string.Empty;

            bool isInvalid = false;
            Dictionary<string, object> _sensorvalue = new Dictionary<string, object>();
            int _tempintvalue = (int)Math.Truncate(decimal.Parse(sensor.Value.ToString()));
            double _purevalue = double.Parse(sensor.Value.ToString());
            double _resultmod = 0.00;
            if (_tempintvalue != 0)
            {
                _resultmod = _purevalue % _tempintvalue;
            }

            if (_resultmod != 0)
            {
                _sensorvalue.Add("key", _purevalue);
                foreach (var item in _sensorvalue)
                {
                    isInvalid = CheckNumeric(item.Value);
                }
                type = isInvalid == true ? "Double" : "NONE";
            }
            else
            {
                _sensorvalue.Add("key", _tempintvalue);
                foreach (var item in _sensorvalue)
                {
                    isInvalid = CheckInt(item.Value);
                }
                type = isInvalid == true ? "Int" : "NONE";
            }
            return type;
        }
       
        public static bool CheckNumeric(object value)
        {
            if (value is double || value is decimal)
                return true;
            else
                return false;
        }       

        public static bool CheckInt16(object value)
        {
            if (value is Int16)
                return true;
            return false;
        }

        public static bool CheckInt(object value)
        {
            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Int16:
                    return true;
                case TypeCode.Int32:
                    return true;
                case TypeCode.Int64:
                    return true;
                default:
                    return false;

            }
        }

        public static bool CheckInt64(object value)
        {
            if (value is Int64)
                return true;

            return false;
        }
    }
}


