using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalc.Controllers;
using TaxCalc.Models;

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
            RateFactory rateFactory = new RateFactory(income);

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

            //Act
            TaxController taxController = new TaxController();
            var result = taxController.GetTaxValue(income);
            decimal actualTaxAmount =decimal.Parse( ((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 28400M;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }

        [TestMethod]
        public void ControllerTestMethod2()
        {
            //Arrange
            decimal income = 50000m;

            //Act
            TaxController taxController = new TaxController();
            var result = taxController.GetTaxValue(income);
            decimal actualTaxAmount = decimal.Parse(((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 15750M;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }

        [TestMethod]
        public void ControllerTestMethod3()
        {
            //Arrange
            decimal income = 30000m;

            //Act
            TaxController taxController = new TaxController();
            var result = taxController.GetTaxValue(income);
            decimal actualTaxAmount = decimal.Parse(((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 6300M;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }

        [TestMethod]
        public void ControllerTestMethod4()
        {
            //Arrange
            decimal income = 10000m;

            //Act
            TaxController taxController = new TaxController();
            var result = taxController.GetTaxValue(income);
            decimal actualTaxAmount = decimal.Parse(((System.Web.Mvc.JsonResult)(result)).Data.ToString());
            decimal expectedTaxAmount = 1150M;

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount);
        }
    }
}
