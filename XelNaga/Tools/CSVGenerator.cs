﻿using Aiursoft.Scanner.Interfaces;
using Aiursoft.XelNaga.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Aiursoft.XelNaga.Tools
{
    public class CSVGenerator : ITransientDependency
    {
        public byte[] BuildFromList<T>(IEnumerable<T> items)
        {
            var csv = "";
            var type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                var attribute = prop.GetCustomAttributes(typeof(CSVProperty), true).FirstOrDefault();
                if (attribute != null)
                {
                    csv += $@"""{(attribute as CSVProperty).Name}"",";
                }
                else
                {
                    csv += $@"""{prop.Name}"",";
                }
            }
            csv = csv.Trim(',') + "\r\n";
            foreach (var item in items)
            {
                string newLine = "";
                foreach (var prop in type.GetProperties())
                {
                    var propValue = prop.GetValue(item)?.ToString() ?? "null";
                    propValue = propValue.Replace("\r", "").Replace("\n", "").Replace("\\", "");
                    newLine += $@"""{propValue }"",";
                }
                newLine = newLine.Trim(',') + "\r\n";
                csv += newLine;
            }
            return csv.ToUTF8WithDom();
        }
    }
}
