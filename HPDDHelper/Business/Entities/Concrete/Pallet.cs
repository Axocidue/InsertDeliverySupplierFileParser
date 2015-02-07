using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Business.Entities.Abstract;
using System.Text.RegularExpressions;

namespace HPDDHelper.Business.Entities.Concrete
{
    public class Pallet
    {
        public List<Masterpack> Masterpacks;

        public string RecordID { get; set; }

        public string PalletNumber { get; set; }

        public string ParentID { get; set; }

        public string ReturnCause { get; set; }

        public Pallet(string raw)
        {
            Initialize(raw);
        }

        public void Initialize(string line)
        {
            Masterpacks = new List<Masterpack>();

            var elements = Regex.Split(line, @"\^\^");
            RecordID = elements[0].Trim();
            PalletNumber = elements[1].Trim();
            ParentID = elements[2].Trim();
            ReturnCause = elements[3].Trim();
        }
    }
}
