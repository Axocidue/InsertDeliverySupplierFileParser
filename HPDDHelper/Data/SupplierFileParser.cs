using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPDDHelper.Business.Entities.Concrete;
using HPDDHelper.Common;
using System.Text.RegularExpressions;

namespace HPDDHelper.Data
{
    public static class SupplierFileParser
    {
        public static Delivery ParseDelivery(this string text)
        {
            Delivery delivery = null;
            var locationID = 0;

            var cursor = new HCursor { Delivery = -1, Pallet = -1, Masterpack = -1, Unit = -1, Code = -1, Component = -1 };

            var lines = text.Split('\n');

            foreach(var line in lines)
            {
                if(line.StartsWith("IN"))
                {
                    delivery = new Delivery(line);
                    locationID = Int32.Parse(delivery.LocationID);
                    cursor.Delivery++;
                    cursor.Pallet = cursor.Masterpack = cursor.Unit = cursor.Code = cursor.Component = -1;
                }

                if(line.StartsWith("02"))
                {
                    var pallet = new Pallet(line);
                    delivery.Pallets.Add(pallet);
                    cursor.Pallet++;
                    cursor.Masterpack = cursor.Unit = cursor.Code = cursor.Component = -1;
                }

                if(line.StartsWith("03"))
                {
                    var masterpack = new Masterpack(line);
                    delivery.Pallets[cursor.Pallet].Masterpacks.Add(masterpack);
                    cursor.Masterpack++;
                    cursor.Unit = cursor.Code = cursor.Component = -1;
                }

                if(line.StartsWith("04"))
                {
                    var unit = new Unit(line, locationID);
                    delivery.Pallets[cursor.Pallet].Masterpacks[cursor.Masterpack].Units.Add(unit);
                    cursor.Unit++;
                    cursor.Code = cursor.Component = -1;
                }

                if(Regex.IsMatch(line,@"^5"))
                {
                    var code = new Code(line);
                    delivery.Pallets[cursor.Pallet].Masterpacks[cursor.Masterpack].Units[cursor.Unit]
                        .Codes.Add(code);
                    cursor.Code++;
                }

                if (Regex.IsMatch(line, @"^6"))
                {
                    var component = new Component(line);
                    delivery.Pallets[cursor.Pallet].Masterpacks[cursor.Masterpack].Units[cursor.Unit]
                        .Components.Add(component);
                    cursor.Component++;
                }
            }            

            return delivery;

        }


        
    }
}
