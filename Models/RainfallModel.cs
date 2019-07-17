using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DailyWeather.Models
{
    [DataContract(Name = "data")]
    public class RainfallModel
    {
        [DataMember(Name = "value")]
        public List<RainfallData> RainfallDataList { get; set; }
    }

    [DataContract(Name = "data")]
    public class RainfallData
    {
        [DataMember(Name = "ref")]
        public string Date { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
