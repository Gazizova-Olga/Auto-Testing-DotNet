using HW_7.Project.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW_7.Project.DataProviders
{
    public class MetalAndColorsDataProvider
    {
        static MetalAndColorsData data;

        public static void GetMetalAnsColorsData()
        {
            string fileName = "MetalAndColors.json";
            string jsonString = File.ReadAllText(fileName);
            MetalAndColorsData metalAndColorsData =
                JsonSerializer.Deserialize<MetalAndColorsData>(jsonString);
            data = metalAndColorsData;
        }
    }
}
