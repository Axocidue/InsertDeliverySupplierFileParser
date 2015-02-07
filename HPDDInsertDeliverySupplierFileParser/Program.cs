using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Data;
using HPDDHelper.Common;

namespace HPDDInsertDeliverySupplierFileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileIn = @"C:\Users\Alexander Guan\Desktop\Supplier File Parser Prep\IC0155_31_20150112111937_10160606.upd";

            var text = fileIn.Load();

            var d = text.ParseDelivery();
        }
    }
}
