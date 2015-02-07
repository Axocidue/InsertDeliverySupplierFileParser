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

            var actual = target.PurchaseOrderLineNumber;
            var expected = @"71238956/132";

            Assert.AreEqual(expected, actual);
        }
    }
}
