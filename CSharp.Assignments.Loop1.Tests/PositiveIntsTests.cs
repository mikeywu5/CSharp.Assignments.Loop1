using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;

namespace CSharp.Assignments.Loop1.Tests
{
    public class PositiveIntsTests
    {

        [Test]
        [Category("Loop")]
        public void TestPositiveInts()
        {
            Action program = new Action(PositiveInts.Main);
            string actual;
            actual = program.Run(10);
            actual.Assert(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            actual = program.Run(4);
            actual.Assert(1, 2, 3, 4);
            actual = program.Run(3);
            actual.Assert(1, 2, 3);
            actual = program.Run(0);
            actual.Assert(); // none.
            actual = program.Run(-2);
            actual.Assert();
            actual = program.Run(-9);
            actual.Assert();
        }
    }    
}
