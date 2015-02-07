using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Business.Entities.Abstract;
using System.Text.RegularExpressions;

namespace HPDDHelper.Business.Entities.Concrete
{
    public class Masterpack
    {
        public List<Unit> Units;

        public string RecordID { get; set; }

        public string MasterpackNumber { get; set; }

        public string ParentID { get; set; }

        public string ReturnCause { get; set; }


        public Masterpack(string raw)
        {
            Initialize(raw);
        }

        public void Initialize(string raw)
        {
            Units = new List<Unit>();

            var elements = Regex.Split(raw, @"\^\^");
            RecordID = elements[0].Trim();
            MasterpackNumber = elements[1].Trim();
            ParentID = elements[2].Trim();
            ReturnCause = elements[3].Trim();
        }

       
    }
}
