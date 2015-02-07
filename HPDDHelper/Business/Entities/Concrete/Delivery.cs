using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Business.Entities.Abstract;
using System.Text.RegularExpressions;

namespace HPDDHelper.Business.Entities.Concrete
{
    public class Delivery
    {
        public List<Pallet> Pallets;

        public string RecordID { get; set; }

        public string PurchaseOrderLineNumber { get; set; }

        public string CustomerNumber { get; set; }

        public string ActualShippingDate { get; set; }

        public string CustomerPONumber { get; set; }

        public string LocationID { get; set; }

        public string SalesItem { get; set; }

        public string SalesItemRevisionState { get; set; }

        public string CommercialModel { get; set; }

        public string Color { get; set; }

        public string LabelText { get; set; }

        public string UnitQuantity { get; set; }

        public string PrototypeFlag { get; set; }

        public string OperatorName { get; set; }

        public string ReturnCause { get; set; }

        public Delivery(string raw)
        {
            Initialize(raw);
        }

        private void Initialize(string line)
        {
            Pallets = new List<Pallet>();

            var elements = Regex.Split(line, @"\^\^");
            RecordID = elements[0].Trim();
            PurchaseOrderLineNumber = elements[1].Trim();
            CustomerNumber = elements[2].Trim();
            ActualShippingDate = elements[3].Trim();
            CustomerPONumber = elements[4].Trim();
            LocationID = elements[5].Trim();
            SalesItem = elements[6].Trim();
            SalesItemRevisionState = elements[7].Trim();
            CommercialModel = elements[8].Trim();
            Color = elements[9].Trim();
            LabelText = elements[10].Trim();
            UnitQuantity = elements[11].Trim();

            var locationID = Int32.Parse(LocationID);
            var bmc = new [] {10, 31, 37, 45};
            var arima_wj = new[] { 35 };
            //var cei_nj = new[] { 36 };
            //var fih_yt = new[] { 88 };
            //var fih_br = new[] { -94 };

            if (bmc.Contains(locationID))
            {
                PrototypeFlag = elements[12].Trim();
                OperatorName = elements[13].Trim();
                ReturnCause = elements[14].Trim();
            }
            else if(arima_wj.Contains(locationID))
            {
                OperatorName = elements[12].Trim();
                ReturnCause = elements[13].Trim();
            }
            else
            {
                ReturnCause = elements[12].Trim();
            }

        }

    }
}
