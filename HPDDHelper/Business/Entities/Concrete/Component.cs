using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Business.Entities.Abstract;
using System.Text.RegularExpressions;

namespace HPDDHelper.Business.Entities.Concrete
{
    public class Component
    {

        public string RecordID { get; set; }

        public string ComponentType { get; set; }

        public string SoMCProductNumber { get; set; }

        public string ProductNumberRevisionState { get; set; }

        public string BatchID { get; set; }

        public string ParentID { get; set; }


        public Component(string raw)
        {
            Initialize(raw);
        }

        public void Initialize(string raw)
        {
            var elements = Regex.Split(raw, @"\^\^");
            RecordID = elements[0].Trim();
            ComponentType = elements[1].Trim();
            SoMCProductNumber = elements[2].Trim(); ;
            ProductNumberRevisionState = elements[3].Trim();
            BatchID = elements[4].Trim();
            ParentID = elements[5].Trim();

        }

       
    }
}
