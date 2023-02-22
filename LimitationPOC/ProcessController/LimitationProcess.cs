using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimitationPOC.EnvModel;
using LimitationPOC.InterfaceSpec;
using LimitationPOC.MongoModels;
using MongoDB.Bson;

namespace LimitationPOC.ProcessController
{
    public class LimitationProcess : ILimitationProcess
    {
        private readonly List<LimitationModels> dbSet = new()
        {
            new LimitationModels() { id = ObjectId.GenerateNewId(), LimitationKey = "Account", LimitationValue = "AccountA", LimitationDetails = new Dictionary<string, object>() { { "TRANSSIZE_KBYTES", 100 }, { "LimitThing_Account", 100 } } },
            new LimitationModels() { id = ObjectId.GenerateNewId(), LimitationKey = "Tenant", LimitationValue = "TenantA", LimitationDetails = new Dictionary<string, object>() { { "TRANSSIZE_KBYTES", 200 }, { "LimitThing_Account", 200 } } },
            new LimitationModels() { id = ObjectId.GenerateNewId(), LimitationKey = "Customer", LimitationValue = "CustomerB", LimitationDetails = new Dictionary<string, object>() { { "TRANSSIZE_KBYTES", 50 }, { "LimitThing_Account", 50 } } },
            new LimitationModels() { id = ObjectId.GenerateNewId(), LimitationKey = "Customer", LimitationValue = "CustomerA", LimitationDetails = new Dictionary<string, object>() { { "TRANSSIZE_KBYTES", 50 }, { "LimitThing_Account", 50 } } },
            new LimitationModels() { id = ObjectId.GenerateNewId(), LimitationKey = "Thing", LimitationValue = "ThingA", LimitationDetails = new Dictionary<string, object>() { { "TRANSSIZE_KBYTES", 50 } } },
            new LimitationModels() { id = ObjectId.GenerateNewId(), LimitationKey = "Environment", LimitationValue = "All", LimitationDetails = new Dictionary<string, object>() { { "TRANSSIZE_KBYTES", 50 }, { "LimitThing_Account", 100 } } }
        };

        public LimitationProcess()
        {

        }

        public List<LimitationResponse> GetLimitationDetial(LimitationRequest req)
        {
            var response = new List<LimitationResponse>();

            var SortedEnv = GetSortedHeirachy();

            List<string> LimitationsKeysRequest = req.LimitationKeyValue.Select(x => x.Key).ToList();
            List<string> LimitationsValuesRequest = req.LimitationKeyValue.Select(x => x.Value).ToList();
            List<string> RuleList = req.Rule.Distinct().ToList();

            //Filter to Db
            var respdb = dbSet.Where(x => LimitationsKeysRequest.Contains(x.LimitationKey) && LimitationsValuesRequest.Contains(x.LimitationValue)).ToList();
            if (respdb != null && respdb.Count > 0)
            {
                int NeedRule = RuleList.Count;

                foreach (var ruleRequest in RuleList)
                {
                    bool AlreadyGetKey = false;
                    if (!AlreadyGetKey)
                    {
                        foreach (var envKey in SortedEnv)
                        {
                            var DataLimitations = respdb.FirstOrDefault(x => x.LimitationKey == envKey.PKey);
                            if (DataLimitations is not null && !AlreadyGetKey)
                            {
                                foreach (var Rule in DataLimitations.LimitationDetails)
                                {
                                    if (Rule.Key == ruleRequest)
                                    {
                                        if (Rule.Value is not null)
                                        {
                                            var respmap = new LimitationResponse()
                                            {
                                                Name = Rule.Key.ToString().Split('_').FirstOrDefault(),
                                                Value = Rule.Value.ToString(),
                                                Unit = Rule.Key.ToString().Split('_').LastOrDefault()
                                            };
                                            response.Add(respmap);
                                            AlreadyGetKey = true;
                                        }
                                    }

                                }
                            }
                           
                        }
                    }
                    

                }
            }
            else
            {
                var env = dbSet.FirstOrDefault(x => x.LimitationKey == "Environment");
                foreach (var ruleRequest in RuleList)
                {
                    foreach (var envRule in env.LimitationDetails)
                    {
                        if (envRule.Key == ruleRequest)
                        {
                            var respmap = new LimitationResponse()
                            {
                                Name = envRule.Key.ToString().Split('_').FirstOrDefault(),
                                Value = envRule.Value.ToString(),
                                Unit = envRule.Key.ToString().Split('_').LastOrDefault()
                            };
                            response.Add(respmap);
                        }
                    }
                }


                return response;
            }


            return response;


        }


        private static List<HeirachyLevels> GetSortedHeirachy()
        {
            var envHeirachy = LimitationPOC.Configuration.HierachyStruct;
            if (envHeirachy is null)
            {
                return null;
            }

            return envHeirachy.OrderByDescending(x => x.PLevel).ToList();
        }
    }
}
