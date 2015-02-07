using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Business.Entities.Abstract;
using System.Text.RegularExpressions;

namespace HPDDHelper.Business.Entities.Concrete
{
    public class Code 
    { 

        public string RecordID { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string ParentID { get; set; }

        public Code(string raw)
        {
            Initialize(raw);
        }

        public void Initialize(string raw)
        {
            var elements = Regex.Split(raw, @"\^\^");
            RecordID = elements[0].Trim();
            Number = elements[1].Trim();
            Name = elements[2].Trim();
            ParentID = elements[3].Trim();
        }

    }
}
