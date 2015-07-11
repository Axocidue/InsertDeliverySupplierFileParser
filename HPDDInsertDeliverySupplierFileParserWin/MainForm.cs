using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPDDHelper.Common;
using HPDDHelper.Business.Entities.Concrete;
using HPDDHelper.Data;
using System.Text.RegularExpressions;

namespace HPDDInsertDeliverySupplierFileParserWin
{
    public partial class MainForm : Form
    {
        private Delivery delivery;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        

        }

        private void tbx_FileIn_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileIn = openFileDialog1.FileName;
                tbx_FileIn.Text = fileIn;
            }
        }

        private void UpdateTreeViewByDelivery(Delivery d)
        {
            tv_Delivery.CollapseAll();
            tv_Delivery.Nodes.Clear();

            var rootNode = new TreeNode("Delivery: " + d.PurchaseOrderLineNumber);
            foreach (var p in d.Pallets)
            {
                var palletNode = new TreeNode("Pallet: " + p.PalletNumber);

                foreach (var m in p.Masterpacks)
                {
                    var masterpackNode = new TreeNode("Masterpack: " + m.MasterpackNumber);

                    foreach (var u in m.Units)
                    {
                        var unitNode = new TreeNode("Unit: " + u.MSN);

                        var codeNode = new TreeNode("Codes: ");

                        foreach (var code in u.Codes)
                        {
                            var codNode = new TreeNode(code.Name + ": " + code.Number);

                            codeNode.Nodes.Add(codNode);
                        }

                        unitNode.Nodes.Add(codeNode);

                        var componentNode = new TreeNode("Components:");

                        foreach (var component in u.Components)
                        {
                            var comNode = new TreeNode(component.ComponentType + ": " + component.BatchID);

                            componentNode.Nodes.Add(comNode);
                        }

                        unitNode.Nodes.Add(componentNode);

                        masterpackNode.Nodes.Add(unitNode);
                    }

                    palletNode.Nodes.Add(masterpackNode);
                }

                rootNode.Nodes.Add(palletNode);
            }

            tv_Delivery.Nodes.Add(rootNode);
            

            //tv_Delivery.ExpandAll();

            tv_Delivery.ShowRootLines = true;

            tv_Delivery.SelectedNode = tv_Delivery.Nodes[0];

            tv_Delivery.Select();
        }

        private void btn_Parse_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tbx_FileIn.Text.Trim()) )
                return;

            var fileIn = tbx_FileIn.Text;

            var text = fileIn.Load();

            delivery = text.ParseDelivery();

            if (AppData.CurrentDelivery != null) AppData.CurrentDelivery = null;
            AppData.CurrentDelivery = delivery;

            UpdateTreeViewByDelivery(AppData.CurrentDelivery);
            
        }

        private void tv_Delivery_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selected = e.Node.Text;

            var sb = new StringBuilder();
            sb.AppendLine("File Type:　INSERT_DELIVERY");
            sb.AppendLine();

            if(selected.StartsWith("Delivery"))
            {
                sb.AppendLine("Delivery Info");
                sb.AppendLine();

                sb.AppendLine("Purchase Order Line Item:　" + delivery.PurchaseOrderLineNumber);
                sb.AppendLine("Customer Number:　" + delivery.CustomerNumber);
                sb.AppendLine("Actual Shipping Date:　" + delivery.ActualShippingDate);
                sb.AppendLine("Customer PO Number:　" + delivery.CustomerPONumber);
                sb.AppendLine("Location ID:　" + delivery.LocationID);
                sb.AppendLine("Sales Item:　" + delivery.SalesItem);
                sb.AppendLine("Sales Item Revision State:　" + delivery.SalesItemRevisionState);
                sb.AppendLine("Commercial Model:　" + delivery.CommercialModel);
                sb.AppendLine("Colour:　" + delivery.Color);
                sb.AppendLine("Label Text:　" + delivery.LabelText);
                sb.AppendLine("Unit Quantity:　" + delivery.UnitQuantity);
                sb.AppendLine("Prototype Flag:　" + delivery.PrototypeFlag);
                sb.AppendLine("Operator Name:　" + delivery.OperatorName);
                sb.AppendLine("Return Cause:　" + delivery.ReturnCause);
            }

            else if(selected.StartsWith("Pallet"))
            {
                sb.AppendLine("Pallet Info");
                sb.AppendLine();

                var palletNumber = Regex.Split(selected, ":")[1].Trim();
                var pallets = from p in delivery.Pallets
                              where p.PalletNumber == palletNumber
                              select p;
                var pallet = pallets.ToArray()[0];

                sb.AppendLine("Pallet Number:　" + pallet.PalletNumber);
                sb.AppendLine("Parent ID:　" + pallet.ParentID);
                sb.AppendLine("Return Cause:　" + pallet.ReturnCause);
            }

            else if(selected.StartsWith("Masterpack"))
            {
                sb.AppendLine("Masterpack Info");
                sb.AppendLine();

                var source = new List<Masterpack>();
                foreach(var p in delivery.Pallets)
                {
                    source.AddRange(p.Masterpacks);
                }

                var masterpackNumber = Regex.Split(selected, ":")[1].Trim();
                var masterpacks = from m in source
                                  where m.MasterpackNumber == masterpackNumber
                                  select m;
                var masterpack = masterpacks.ToArray()[0];

                sb.AppendLine("Masterpack Number:　" + masterpack.MasterpackNumber);
                sb.AppendLine("Parent ID:　" + masterpack.ParentID);
                sb.AppendLine("Return Cause:　" + masterpack.ReturnCause);
            }

            else if(selected.StartsWith("Unit"))
            {
                sb.AppendLine("Unit Info");
                sb.AppendLine();

                var source = new List<Unit>();
                foreach(var p in delivery.Pallets)
                {
                    foreach(var m in p.Masterpacks)
                    {
                        source.AddRange(m.Units);
                    }
                }

                var unitNumber = Regex.Split(selected, ":")[1].Trim();
                var units = from u in source
                            where u.MSN == unitNumber
                            select u;
                var unit = units.ToArray()[0];

                sb.AppendLine("MSN:　" + unit.MSN);
                sb.AppendLine("Manufacturing Date:　" + unit.ManufactoringDate);
                sb.AppendLine("Core Unit Number:　" + unit.CoreUnitNumber);
                sb.AppendLine("Core Unit Number Revision State:　" + unit.CoreUnitNumberRevisionState);
                sb.AppendLine("APPSW Product Number:　" + unit.APPSWProductNumber);
                sb.AppendLine("APPSW Version Number:　" + unit.APPSWVersionNumber);
                sb.AppendLine("APPSW Revision State:　" + unit.APPSWRevisionState);
                sb.AppendLine("Sales Item:　" + unit.SalesItem);
                sb.AppendLine("Sales Item Revision State:　" + unit.SalesItemRevisionState);
                sb.AppendLine("CDF Product Number:　" + unit.CDFProductNumber);
                sb.AppendLine("CDF Version Number:　" + unit.CDFVersionNumber);
                sb.AppendLine("CDF Revision State:　" + unit.CDFRevisionState);
                sb.AppendLine("SWC Product Number:　" + unit.SWCProductNumber);
                sb.AppendLine("SWC Revision State:　" + unit.SWCRevisionState);
                sb.AppendLine("Parent ID:　" + unit.ParentID);
                sb.AppendLine("Return Cause:　" + unit.ReturnCause);

            }

            else if(selected.StartsWith("Codes"))
            {
                sb.AppendLine("Codes");
                sb.AppendLine();

                var parent = e.Node.Parent.Text;

                var source = new List<Unit>();
                foreach (var p in delivery.Pallets)
                {
                    foreach (var m in p.Masterpacks)
                    {
                        source.AddRange(m.Units);
                    }
                }

                var unitNumber = Regex.Split(parent, ":")[1].Trim();
                var units = from u in source
                            where u.MSN == unitNumber
                            select u;
                var unit = units.ToArray()[0];

                foreach(var code in unit.Codes)
                {
                    sb.AppendLine( code.Name +  ":　" + code.Number);
                }

            }

            else if(selected.StartsWith("Components"))
            {
                sb.AppendLine("Components");
                sb.AppendLine();

                var parent = e.Node.Parent.Text;

                var source = new List<Unit>();
                foreach (var p in delivery.Pallets)
                {
                    foreach (var m in p.Masterpacks)
                    {
                        source.AddRange(m.Units);
                    }
                }

                var unitNumber = Regex.Split(parent, ":")[1].Trim();
                var units = from u in source
                            where u.MSN == unitNumber
                            select u;
                var unit = units.ToArray()[0];

                foreach (var com in unit.Components)
                {
                    sb.AppendLine(com.ComponentType + ":　" + com.BatchID);
                }
            }

            else
            {
                var parent = e.Node.Parent.Text;
                var grand = e.Node.Parent.Parent.Text;
                var unit = Regex.Split(grand, ":")[1].Trim();

                if(parent.StartsWith("Code"))
                {
                    sb.AppendLine("Code Info");
                    sb.AppendLine();

                    var source = new List<Code>();
                    foreach(var p in delivery.Pallets)
                    {
                        foreach(var m in p.Masterpacks)
                        {
                            foreach(var u in m.Units)
                            {
                                source.AddRange(u.Codes);
                            }
                        }
                    }
                    
                    var codeNumber = Regex.Split(selected, ":")[0].Trim();
                    var codes = from c in source
                                where c.Name == codeNumber && c.ParentID == unit
                                select c;
                    var code = codes.ToArray()[0];

                    sb.AppendLine("Code Name:　" + code.Name);
                    sb.AppendLine("Code Number:　" + code.Number);
                    sb.AppendLine("Parent ID:　" + code.ParentID);

                }
                else if(parent.StartsWith("Component"))
                {
                    sb.AppendLine("Component Info");
                    sb.AppendLine();

                    var source = new List<
                        HPDDHelper.Business.Entities.Concrete.Component>();
                    foreach (var p in delivery.Pallets)
                    {
                        foreach (var m in p.Masterpacks)
                        {
                            foreach (var u in m.Units)
                            {
                                source.AddRange(u.Components);
                            }
                        }
                    }
                    var comNumber = Regex.Split(selected, ":")[0].Trim();
                    var components = from c in source
                                     where c.ComponentType == comNumber && c.ParentID == unit
                                select c;
                    var component = components.ToArray()[0];

                    sb.AppendLine("Component Type:　" + component.ComponentType);
                    sb.AppendLine("SoMC Product Number:　" + component.SoMCProductNumber);
                    sb.AppendLine("Product Number Revision State:　" + component.ProductNumberRevisionState);
                    sb.AppendLine("Batch ID:　" + component.BatchID);
                    sb.AppendLine("Parent ID:　" + component.ParentID);
                }
                else
                {
                    sb.AppendLine(selected);
                }
                
            }


            tbx_Detail.Text = sb.ToString();
        }
    }
}
