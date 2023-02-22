using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimitationPOC.EnvModel;
using Newtonsoft.Json;

namespace LimitationPOC
{
    public class Configuration
    {
        public static List<HeirachyLevels> HierachyStruct
        {
            get
            {
                List<HeirachyLevels> resp;
                try
                {
                    if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("HierachyStruct")))
                    {
                        resp = JsonConvert.DeserializeObject<List<HeirachyLevels>>(Environment.GetEnvironmentVariable("HierachyStruct"));

                        if (resp is null)
                        {
                            throw new System.Exception("HierachyStruct is empty. Please check ENV.");
                        }
                        else
                        {
                            if (resp.Any(x=>x.PKey == null)|| resp.Any(x => x.PLevel == null))
                            {
                                throw new System.Exception("HierachyStruct is empty. Please check ENV.");
                            }
                        }
                    }
                    else
                    {
                        throw new System.Exception("HierachyStruct is empty. Please check ENV.");
                    }
                }
                catch (Exception ex)
                {
                    throw new System.Exception($"HierachyStruct : {ex.Message}");
                }
                return resp;
            }
        }
    }
}
