using System;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
namespace CSharp.Assignments.Loop1.Tests
{
    public class GasMileageTests
    {
        const string Case1 = "Sentinel Break";
        const string Case2 = "1 MPG";
        const string Case3 = "1 MPG (rounded)";
        const string Case4 = "Negative MPG";
        const string Case5 = "Sentinel Control Loop";

        [TestCase(Case1, Description = Case1)]
        [TestCase(Case2, Description = Case2)]
        [TestCase(Case3, Description = Case3)]
        [TestCase(Case4, Description = Case4)]
        [TestCase(Case5, Description = Case5)]
        [Category("Sentinel")]
        public void TestGasMileage(string testCase)
        {
            Action app = new Action(GasMileage.Main);
            string result, result2;
            switch (testCase)
            {
                case Case1:
                    result = app.Run(-1);
                    result2 = app.Run(-1, 10, -1);
                    Assert.AreEqual(result, result2, "When the mileage driven is set to -1, the loop should have exited and should not ask for further inputs.");
                    result2 = app.Run(1, 10, -1);
                    Assert.AreNotEqual(result, result2, "There should be some logic.");
                    break;

                case Case2:
                    result = app.Run(161, 23, -1);
                    result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        7, // current miles per gallon
                        7, // total miles per gallon
                        ExpectTo.Go
                    );
                    break;

                case Case3:
                    result = app.Run(154, 13, -1);
                    result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        11.85, // current miles per gallon
                        11.85, // total miles per gallon
                        ExpectTo.Go
                    );
                    break;

                case Case4:
                    result = app.Run(161, -23, -1);
                    Assert.IsNotEmpty(result, "There should be some code.");
                    result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.NotMatch,
                        -7 // current miles per gallon
                    );
                    break;

                case Case5:
                    result = app.Run(
                        39, 1,
                        42, 2,
                        31, 3,
                        22, 4,
                        49, 5,
                        82, 6,
                        87, 7,
                        72, 8,
                        61, 9,
                        20, 10,
                        -1, 1);
                    /*
                     * MPG this tankful: 39.00
                     * Total MPG: 39.00
                     * MPG this tankful: 21.00
                     * Total MPG: 27.00
                     * MPG this tankful: 10.33
                     * Total MPG: 18.67
                     * MPG this tankful: 5.50
                     * Total MPG: 13.40
                     * MPG this tankful: 9.80
                     * Total MPG: 12.20
                     * MPG this tankful: 13.67
                     * Total MPG: 12.62
                     * MPG this tankful: 12.43
                     * Total MPG: 12.57
                     * MPG this tankful: 9.00
                     * Total MPG: 11.78
                     * MPG this tankful: 6.78
                     * Total MPG: 10.78
                     * MPG this tankful: 2.00
                     * Total MPG: 9.18
                     * Enter miles (-1 to quit):                    
                     */
                    result = result.Assert(
                       ExpectTo.AssertContinuously | ExpectTo.Match,
                       @"\b39(\.[0]*)?\b",
                       @"\b39(\.[0]*)?\b",
                       ExpectTo.Go
                   );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b21(\.[0]*)?\b",
                        @"\b27(\.[0]*)?\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b10\.33[0]*\b",
                        @"\b18\.67[0]*\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b5\.5[0]*\b",
                        @"\b13\.4[0]*\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b9\.8[0]*\b",
                        @"\b12\.2[0]*\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b13\.67[0]*\b",
                        @"\b12\.62[0]*\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b12\.43[0]*\b",
                        @"\b12\.57[0]*\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b9(\.[0]*)?\b",
                        @"\b11\.78[0]*\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b6\.78[0]*\b",
                        @"\b10\.78[0]*\b",
                        ExpectTo.Go
                    );
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Match,
                        @"\b2(\.[0]*)\b",
                        @"\b9\.18[0]*\b",
                        ExpectTo.Go
                    );

                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.NotMatch,
                        @"\d{2}"
                    );
                    break;
            }
        }
    }
}
