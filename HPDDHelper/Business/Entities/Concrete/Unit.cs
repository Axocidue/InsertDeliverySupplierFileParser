using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Business.Entities.Abstract;
using System.Text.RegularExpressions;

namespace HPDDHelper.Business.Entities.Concrete
{
    public class Unit
    {
        public List<Code> Codes;

        public List<Component> Components;

        public string RecordID { get; set; }

        public string MSN { get; set; }

        public string PREV_MSN { get; set; }

        public string ManufactoringDate { get; set; }

        public string CoreUnitNumber { get; set; }

        public string CoreUnitNumberRevisionState { get; set; }

        public string APPSWProductNumber { get; set; }

        public string APPSWVersionNumber { get; set; }

        public string APPSWRevisionState { get; set; }

        public string SalesItem { get; set; }

        public string SalesItemRevisionState { get; set; }

        public string CDFProductNumber { get; set; }

        public string CDFVersionNumber { get; set; }

        public string CDFRevisionState { get; set; }

        public string SWCProductNumber { get; set; }

        public string SWCRevisionState { get; set; }

        public string ParentID { get; set; }

        public string ReturnCause { get; set; }


        public Unit(string raw, int locationID)
        {
            Initialize(raw, locationID);
        }


        public void Initialize(string raw, int locationID)
        {
            Codes = new List<Code>();
            Components = new List<Component>();

            var elements = Regex.Split(raw, @"\^\^");

            RecordID = elements[0].Trim();
            MSN = elements[1].Trim();
            ManufactoringDate = elements[2].Trim();
            CoreUnitNumber = elements[3].Trim();
            CoreUnitNumberRevisionState = elements[4].Trim();
            APPSWProductNumber = elements[5].Trim();
            APPSWVersionNumber = elements[6].Trim();
            APPSWRevisionState = elements[7].Trim();
            SalesItem = elements[8].Trim();
            SalesItemRevisionState = elements[9].Trim();
            CDFProductNumber = elements[10].Trim();

            var withCDFVersionNumber = new[] { 10, 31, 37, 45, 88, 36 };
            if(withCDFVersionNumber.Contains(locationID))
            {
                
                CDFVersionNumber = elements[11].Trim();
                CDFRevisionState = elements[12].Trim();
                SWCProductNumber = elements[13].Trim();
                SWCRevisionState = elements[14].Trim();
                ParentID = elements[15].Trim();
                ReturnCause = elements[16].Trim();

            }
            else
            {
                //CDFVersionNumber = elements[11].Trim();
                CDFRevisionState = elements[11].Trim();
                SWCProductNumber = elements[12].Trim();
                SWCRevisionState = elements[13].Trim();
                ParentID = elements[14].Trim();
                ReturnCause = elements[15].Trim();
            }

        }

    }
}
