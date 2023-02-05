using Epam.JDI.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HW_7.Project.Entities
{
    public class MetalAndColorsData
    {
        [JsonPropertyName("summary")]
        [Name("Summary")]
        public IList<int> Summary { get; set; }
        [JsonPropertyName("elements")]
        public IList<string> Elements { get; set; }
        [JsonPropertyName("colors")]
        public string Colors { get; set; }
        [JsonPropertyName("metals")]
        public string Metals { get; set; }
        [JsonPropertyName("vegetables")]
        public IList<string> Vegetables { get; set; }
    }
}
