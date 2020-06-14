using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace ETB.Utilities
{
    public static class ExternalUtility
    {
        private static IEnumerable<string> GetDescriptions(Enum value)
        {
            var descs = new List<string>();
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var field = type.GetField(name);
            var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            foreach (DescriptionAttribute fd in fds)
            {
                descs.Add(fd.Description);
            }
            return descs;
        }

        public static string GetFileContent(string filePath)
        {
            string content = string.Empty;
            try
            {
                var sr = new StreamReader(filePath);
                {
                    content = sr.ReadToEnd();
                }
                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> GetNoOfSelectItemList(string commSepData, string selVal)
        {
            
            var noOfRowlst = commSepData.Split(',').ToList();
            var rowOption = selVal;
            List<SelectListItem> NoOfRowsSelItemLst = new List<SelectListItem>();
            foreach (var x in noOfRowlst)
            {
                NoOfRowsSelItemLst.Add(new SelectListItem() { Value = x, Text = x, Selected = (x == rowOption) });
            }

            return NoOfRowsSelItemLst;
        }
    }
}
