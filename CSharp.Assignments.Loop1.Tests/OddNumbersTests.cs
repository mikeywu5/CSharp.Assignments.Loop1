using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
namespace CSharp.Assignments.Loop1.Tests
{
    public class OddNumbersTests
    {
        [Test]
        [Category("Loop")]
        public void TestOddNumbers()
        {

            Action app = new Action(OddNumbers.Main);
            app.Run(5, 10).Assert(5, 7, 9);
            app.Run(6, 11).Assert(7, 9, 11);
            app.Run(6, 12).Assert(7, 9, 11);
            app.Run(-5, 0).Assert(-5, -3, -1);
            app.Run(-5, 7).Assert(-5, -3, -1, 1, 3, 5, 7);
        }

    }
}
