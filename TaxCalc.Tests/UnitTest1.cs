using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalc.Controllers;
using TaxCalc.Models;
using Moq;

namespace TaxCalc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FactoryTestMethod1()
        {
            //Arrange
            decimal income = 10000m;
            IRateFactory rateFactory = new RateFactory(income);

            //Act
            decimal resultRate = rateFactory.getTaxRate();
            decimal expectedRate= 0.115m;

            //Assert
            Assert.AreEqual(expectedRate, resultRate);
        }

        [TestMethod]
        public void FactoryTestMethod2()
        {
            //Arrange
            decimal income = 30000m;
            RateFactory rateFactory = new RateFactory(income);

            //Act
            decimal resultRate = rateFactory.getTaxRate();
            decimal expectedRate = 0.21m;

            //Assert
            Assert.AreEqual(expectedRate, resultRate);
        }

        [TestMethod]
        public void FactoryTestMethod3()
        {
            //Arrange
            decimal income = 50000m;
            RateFactory rateFactory = new RateFactory(income);

            //Act
            decimal resultRate = rateFactory.getTaxRate();
            decimal expectedRate = 0.315m;

            //Assert
            Assert.AreEqual(expectedRate, resultRate);
        }

        [TestMethod]
        public void FactoryTestMethod4()
        {
            //Arrange
            decimal income = 80000m;
            RateFactory rateFactory = new RateFactory(income);

            //Act
            
            decimal resultRate = rateFactory.getTaxRate();
            decimal expectedRate = 0.355m;

            //Assert
            Assert.AreEqual(expectedRate, resultRate);
        }

        [TestMethod]
        public void ControllerTestMethod1()
        {
            //Arrange
            decimal income = 80000m;
            IRateFactory rateFactory= new RateFactory(income);
            //Act
            TaxController taxController = new TaxController(rateFactory);
            var result = taxController.GetTaxValue();
            decimal actualTaxAmount =decimal.Parse( ((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 19230m;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }

        [TestMethod]
        public void ControllerTestMethod2()
        {
            //Arrange
            decimal income = 50000m;
            IRateFactory rateFactory = new RateFactory(income);

            //Act
            TaxController taxController = new TaxController(rateFactory);
            var result = taxController.GetTaxValue();
            decimal actualTaxAmount = decimal.Parse(((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 9380M;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }

        [TestMethod]
        public void ControllerTestMethod3()
        {
            //Arrange
            decimal income = 30000m;
            IRateFactory rateFactory = new RateFactory(income);

            //Act
            TaxController taxController = new TaxController(rateFactory);
            var result = taxController.GetTaxValue();
            decimal actualTaxAmount = decimal.Parse(((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 4970M;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }

        [TestMethod]
        public void ControllerTestMethod4()
        {
            //Arrange
            decimal income = 10000m;
            IRateFactory rateFactory = new RateFactory(income);

            //Act
            TaxController taxController = new TaxController(rateFactory);
            var result = taxController.GetTaxValue();
            decimal actualTaxAmount = decimal.Parse(((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 1150M;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }

        [TestMethod]
        public void TotalTaxMethod1()
        {
            //Arrange
            RateFactory rf = new RateFactory(80000m);

            //Act
            decimal totalTax = rf.totalTax();

            //Assert
            Assert.AreEqual(19230m, totalTax);
        }

        [TestMethod]
        public void TotalTaxMethod2()
        {
            //Arrange
            RateFactory rf = new RateFactory(14000m);

            //Act
            decimal totalTax = rf.totalTax();

            //Assert
            Assert.AreEqual(14000m*0.115m, totalTax);
        }

        [TestMethod]
        public void ControllerOnlyTest()
        {
            //Arrange
            Mock<IRateFactory> mock = new Mock<IRateFactory>();
            mock.Setup(m => m.totalTax()).Returns(5800m);
            TaxController tc = new TaxController(mock.Object);

            //Act
            decimal actualTaxAmount = decimal.Parse(((System.Web.Mvc.JsonResult)(tc.GetTaxValue())).Data.ToString());

            //Assert
            Assert.AreEqual(5800m, actualTaxAmount);
        }

    }
}
