using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxDayAutomation.UITests
{
    public class Calc
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("CalculatorTests")]
    [AllureDisplayIgnored]
    class Calculator
    {
        [Test(Description = "Add two integers and returns the sum")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("8911")]
        [AllureTms("532")]
        [AllureOwner("Anton")]
        [AllureSubSuite("Add")]
        public void Return4_WhenAdd2And2()
        {
            var calculator = new Calc();
            int actualResult = calculator.Add(2, 2);
            Assert.AreEqual(4, actualResult);
        }
        [Test(Description = "Add two integers and returns the sum")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSubSuite("Add")]
        public void Return0_WhenAdd0And0()
        {
            var calculator = new Calc();
            int actualResult = calculator.Add(0, 0);
            Assert.AreEqual(0, actualResult);
        }
        [Test(Description = "Add two integers and returns the sum")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSubSuite("Add")]
        public void ReturnMinus5_WhenAddMinus3AndMinus2()
        {
            var calculator = new Calc();
            int actualResult = calculator.Add(0, 0);
            Assert.AreEqual(1, 1);
        }
    }
}
