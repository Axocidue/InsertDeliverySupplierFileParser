using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace HPDDHelper.Common
{
    public static class FileHelper
    {
        public static string Load(this string fileIn)
        {
            return File.ReadAllText(fileIn);
        }

        public static void Dump(this string text, string fileOut)
        {
            File.WriteAllText(fileOut, text);
        }
    }
}
