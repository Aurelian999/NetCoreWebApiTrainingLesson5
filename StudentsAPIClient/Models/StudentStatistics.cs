using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentsAPIClient.Models
{
    public class StudentStatistics
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("commits")]
        public int Commits { get; set; }
        [JsonPropertyName("lines")]
        public long? Lines { get; set; }
    }

    public enum OrderBy
    {
        Name,
        Commits,
        Lines
    }

}
