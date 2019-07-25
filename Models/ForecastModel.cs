using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DailyWeather.Models
{
    [DataContract(Name = "data")]
    public class ForecastModel
    {
        [DataMember(Name = "approvedTime")]
        public String ApprovedTime { get; set; }
        [DataMember(Name = "referenceTime")]
        public String ReferenceTime { get; set; }
        [DataMember(Name = "timeSeries")]
        public List<TimeSerie> TimeSeries { get; set; }
    }

    [DataContract(Name = "data")]
    public class TimeSerie
    {
        [DataMember(Name = "validTime")]
        public string ValidTime { get; set; }
        [DataMember(Name = "parameters")]
        public List<Parameter> Parameters { get; set; }

    }

    [DataContract(Name = "data")]
    public class Parameter
    {
        [DataMember(Name = "name")]
        public String Name { get; set; }
        [DataMember(Name = "levelType")]
        public String LevelType { get; set; }
        [DataMember(Name = "level")]
        public int Level { get; set; }
        [DataMember(Name = "unit")]
        public String Unit { get; set; }
        [DataMember(Name = "values")]
        public List<Double> Values { get; set; }

    }
}
