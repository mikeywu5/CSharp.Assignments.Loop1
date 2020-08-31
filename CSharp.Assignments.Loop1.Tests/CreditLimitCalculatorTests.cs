using System;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
namespace CSharp.Assignments.Loop1.Tests
{
    public class CreditLimitCalculatorTests
    {
        const string Case1 = "No account";
        const string Case2 = "One account: under the limit";
        const string Case3 = "One account: over the limit";
        const string Case4 = "Multiple accounts";

        [TestCase(Case1, Description = Case1)]
        [TestCase(Case2, Description = Case2)]
        [TestCase(Case3, Description = Case3)]
        [TestCase(Case4, Description = Case4)]
        [Category("Sentinel")]
        public void TestCreditLimitCalculator(string testCase)
        {
            Action app = new Action(CreditLimitCalculator.Main);
            string result, result2;
            int newBalance;
            switch (testCase)
            {
                case Case1:
                    result = app.Run(-1);
                    result2 = app.Run(-1, 1000, 500, 500, 3000, -1);
                    Assert.AreEqual(result, result2, "When an account is negative, the loop should have terminated.");
                    result2 = app.Run(1, 1000, 500, 500, 3000, -1);
                    Assert.AreNotEqual(result, result2, "There should be some logic here.");
                    break;

                case Case2:
                    result = app.Run(123456, 1000, 451, 523, 3000, -1);
                    newBalance = 928;
                    result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        newBalance, // expected balance
                        ExpectTo.NotMatch,
                        "Credit limit exceeded",
                        ExpectTo.Go);
                    break;

                case Case3:
                    result = app.Run(777777, 1234, 2123, 1744, 1500, -1);
                    newBalance = 1613;
                    result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        newBalance, // expected balance
                        ExpectTo.Match,
                        "Credit limit exceeded",
                        ExpectTo.Go);
                    break;

                case Case4:
                    result = app.Run(
                        123456, 1000, 451, 523, 3000,
                        777777, 1234, 2123, 1744, 1500,
                        1854332, 43, 123, 111, 54,
                        1775434, 43, 123, 111, 55,
                        -1, 43, 123, 111, 60, // sentinel
                        -1, 43, 123, 111, 60); // redundant

                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        928, // expected balance
                        ExpectTo.NotMatch,
                        "Credit limit exceeded",
                        ExpectTo.Go);

                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        1613, // expected balance
                        ExpectTo.Match,
                        "Credit limit exceeded",
                        ExpectTo.Go);

                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        55, // expected balance
                        ExpectTo.Match,
                        "Credit limit exceeded",
                        ExpectTo.Go);

                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        55, // expected balance
                        ExpectTo.NotMatch,
                        "Credit limit exceeded",
                        ExpectTo.Go);

                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.NotMatch,
                        55);

                    break;

            }
        }
    }
}
