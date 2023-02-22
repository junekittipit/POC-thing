using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LimitationPOC.MongoModels
{
    public class LimitationModels
    {
        public ObjectId id { get; set; }
        public string LimitationKey { get; set; }
        public string LimitationValue { get; set; }
        public Dictionary<string,object> LimitationDetails { get; set; }
    }
}
