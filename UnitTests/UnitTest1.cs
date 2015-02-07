using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HPDDHelper.Business.Entities.Concrete;
using HPDDHelper.Common;
using HPDDHelper.Data;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanParseFileToDelivery()
        {
            var filename = @"C:\Users\strategydev\Documents\GitHub\InsertDeliverySupplierFileParser\File Preparation\IC0155_31_20150112111937_10160606.upd";
            var target = filename.Load().ParseDelivery();
            //bug fixed by ag-sp3
            //cause analysis: Missed to load the file content from the filename
            //solution: load the file content before parsing the raw text to delivery 

            var actual = target.PurchaseOrderLineNumber;
            var expected = @"71238956/132";

            Assert.AreEqual(expected, actual);
        }
    }
}
