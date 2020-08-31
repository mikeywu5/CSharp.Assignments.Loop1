using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CSharp.Assignments.Loop1.Tests
{
    public class Logic1Tests
    {

        [Test]
        [Category("Selection")]
        public void CigarParty()
        {
            Assert.AreEqual(false, Logic1.CigarParty(30, true));
            Assert.AreEqual(true, Logic1.CigarParty(50, true));
            Assert.AreEqual(true, Logic1.CigarParty(60, false));
            Assert.AreEqual(false, Logic1.CigarParty(61, false));
            Assert.AreEqual(true, Logic1.CigarParty(40, false));
            Assert.AreEqual(false, Logic1.CigarParty(39, false));
            Assert.AreEqual(true, Logic1.CigarParty(40, true));
            Assert.AreEqual(false, Logic1.CigarParty(39, true));
            Assert.AreEqual(true, Logic1.CigarParty(70, true));
        }

        [Test]
        [Category("Selection")]
        public void CaughtSpeeding()
        {
            Assert.AreEqual(0, Logic1.CaughtSpeeding(60, false));
            Assert.AreEqual(1, Logic1.CaughtSpeeding(65, false));
            Assert.AreEqual(0, Logic1.CaughtSpeeding(65, true));
            Assert.AreEqual(1, Logic1.CaughtSpeeding(80, false));
            Assert.AreEqual(2, Logic1.CaughtSpeeding(85, false));
            Assert.AreEqual(1, Logic1.CaughtSpeeding(85, true));
            Assert.AreEqual(1, Logic1.CaughtSpeeding(70, false));
            Assert.AreEqual(1, Logic1.CaughtSpeeding(75, false));
            Assert.AreEqual(1, Logic1.CaughtSpeeding(75, true));
            Assert.AreEqual(0, Logic1.CaughtSpeeding(40, false));
            Assert.AreEqual(0, Logic1.CaughtSpeeding(40, true));
            Assert.AreEqual(2, Logic1.CaughtSpeeding(90, false));
        }

        [Test]
        [Category("Selection")]
        public void Love6()
        {
            Assert.AreEqual(true, Logic1.Love6(6, 4));
            Assert.AreEqual(false, Logic1.Love6(4, 5));
            Assert.AreEqual(true, Logic1.Love6(1, 5));
            Assert.AreEqual(true, Logic1.Love6(1, 6));
            Assert.AreEqual(false, Logic1.Love6(1, 8));
            Assert.AreEqual(true, Logic1.Love6(1, 7));
            Assert.AreEqual(false, Logic1.Love6(7, 5));
            Assert.AreEqual(true, Logic1.Love6(8, 2));
            Assert.AreEqual(true, Logic1.Love6(6, 6));
            Assert.AreEqual(false, Logic1.Love6(-6, 2));
            Assert.AreEqual(true, Logic1.Love6(-4, -10));
            Assert.AreEqual(false, Logic1.Love6(-7, 1));
            Assert.AreEqual(true, Logic1.Love6(7, -1));
            Assert.AreEqual(true, Logic1.Love6(-6, 12));
            Assert.AreEqual(false, Logic1.Love6(-2, -4));
            Assert.AreEqual(true, Logic1.Love6(7, 1));
            Assert.AreEqual(false, Logic1.Love6(0, 9));
            Assert.AreEqual(false, Logic1.Love6(8, 3));
            Assert.AreEqual(true, Logic1.Love6(3, 3));
            Assert.AreEqual(false, Logic1.Love6(3, 4));
        }

        [Test]
        [Category("Selection")]
        public void More20()
        {
            Assert.AreEqual(false, Logic1.More20(20));
            Assert.AreEqual(true, Logic1.More20(21));
            Assert.AreEqual(true, Logic1.More20(22));
            Assert.AreEqual(false, Logic1.More20(23));
            Assert.AreEqual(false, Logic1.More20(25));
            Assert.AreEqual(false, Logic1.More20(30));
            Assert.AreEqual(false, Logic1.More20(31));
            Assert.AreEqual(false, Logic1.More20(59));
            Assert.AreEqual(false, Logic1.More20(60));
            Assert.AreEqual(true, Logic1.More20(61));
            Assert.AreEqual(true, Logic1.More20(62));
            Assert.AreEqual(false, Logic1.More20(1020));
            Assert.AreEqual(true, Logic1.More20(1021));
            Assert.AreEqual(false, Logic1.More20(1000));
            Assert.AreEqual(true, Logic1.More20(1001));
            Assert.AreEqual(false, Logic1.More20(50));
            Assert.AreEqual(false, Logic1.More20(55));
            Assert.AreEqual(false, Logic1.More20(40));
            Assert.AreEqual(true, Logic1.More20(41));
            Assert.AreEqual(false, Logic1.More20(39));
            Assert.AreEqual(true, Logic1.More20(42));
        }

        [Test]
        [Category("Selection")]
        public void NearTen()
        {
            Assert.AreEqual(true, Logic1.NearTen(12));
            Assert.AreEqual(false, Logic1.NearTen(17));
            Assert.AreEqual(true, Logic1.NearTen(19));
            Assert.AreEqual(true, Logic1.NearTen(31));
            Assert.AreEqual(false, Logic1.NearTen(6));
            Assert.AreEqual(true, Logic1.NearTen(10));
            Assert.AreEqual(true, Logic1.NearTen(11));
            Assert.AreEqual(true, Logic1.NearTen(21));
            Assert.AreEqual(true, Logic1.NearTen(22));
            Assert.AreEqual(false, Logic1.NearTen(23));
            Assert.AreEqual(false, Logic1.NearTen(54));
            Assert.AreEqual(false, Logic1.NearTen(155));
            Assert.AreEqual(true, Logic1.NearTen(158));
            Assert.AreEqual(false, Logic1.NearTen(3));
            Assert.AreEqual(true, Logic1.NearTen(1));
        }

        [Category("Selection")]
        public void TeaParty()
        {
            Assert.AreEqual(1, Logic1.TeaParty(6, 8));
            Assert.AreEqual(0, Logic1.TeaParty(3, 8));
            Assert.AreEqual(2, Logic1.TeaParty(20, 6));
            Assert.AreEqual(2, Logic1.TeaParty(12, 6));
            Assert.AreEqual(1, Logic1.TeaParty(11, 6));
            Assert.AreEqual(0, Logic1.TeaParty(11, 4));
            Assert.AreEqual(0, Logic1.TeaParty(4, 5));
            Assert.AreEqual(1, Logic1.TeaParty(5, 5));
            Assert.AreEqual(1, Logic1.TeaParty(6, 6));
            Assert.AreEqual(2, Logic1.TeaParty(5, 10));
            Assert.AreEqual(1, Logic1.TeaParty(5, 9));
            Assert.AreEqual(0, Logic1.TeaParty(10, 4));
            Assert.AreEqual(2, Logic1.TeaParty(10, 20));
        }


        [Test]
        [Category("Selection")]
        public void SquirrelPlay()
        {
            Assert.AreEqual(true, Logic1.SquirrelPlay(70, false));
            Assert.AreEqual(false, Logic1.SquirrelPlay(95, false));
            Assert.AreEqual(true, Logic1.SquirrelPlay(95, true));
            Assert.AreEqual(true, Logic1.SquirrelPlay(90, false));
            Assert.AreEqual(true, Logic1.SquirrelPlay(90, true));
            Assert.AreEqual(false, Logic1.SquirrelPlay(50, false));
            Assert.AreEqual(false, Logic1.SquirrelPlay(50, true));
            Assert.AreEqual(false, Logic1.SquirrelPlay(100, false));
            Assert.AreEqual(true, Logic1.SquirrelPlay(100, true));
            Assert.AreEqual(false, Logic1.SquirrelPlay(105, true));
            Assert.AreEqual(false, Logic1.SquirrelPlay(59, false));
            Assert.AreEqual(false, Logic1.SquirrelPlay(59, true));
            Assert.AreEqual(true, Logic1.SquirrelPlay(60, false));
        }

        [Test]
        [Category("Selection")]
        public void AlarmClock()
        {
            Assert.AreEqual("7:00", Logic1.AlarmClock(DayOfWeek.Monday, false));
            Assert.AreEqual("7:00", Logic1.AlarmClock(DayOfWeek.Friday, false));
            Assert.AreEqual("10:00", Logic1.AlarmClock(DayOfWeek.Sunday, false));
            Assert.AreEqual("10:00", Logic1.AlarmClock(DayOfWeek.Saturday, false));
            Assert.AreEqual("off", Logic1.AlarmClock(DayOfWeek.Sunday, true));
            Assert.AreEqual("off", Logic1.AlarmClock(DayOfWeek.Saturday, true));
            Assert.AreEqual("10:00", Logic1.AlarmClock(DayOfWeek.Monday, true));
            Assert.AreEqual("10:00", Logic1.AlarmClock(DayOfWeek.Wednesday, true));
            Assert.AreEqual("10:00", Logic1.AlarmClock(DayOfWeek.Friday, true));
        }


        [Test]
        [Category("Selection")]
        public void AnswerCell()
        {
            Assert.AreEqual(true, Logic1.AnswerCell(false, false, false));
            Assert.AreEqual(false, Logic1.AnswerCell(false, false, true));
            Assert.AreEqual(false, Logic1.AnswerCell(true, false, false));
            Assert.AreEqual(true, Logic1.AnswerCell(true, true, false));
            Assert.AreEqual(true, Logic1.AnswerCell(false, true, false));
            Assert.AreEqual(false, Logic1.AnswerCell(true, true, true));
        }

        [Test]
        [Category("Loop")]
        public void IsHilly()
        {
            Assert.IsFalse(Logic1.IsHilly(1));
            Assert.IsFalse(Logic1.IsHilly(12));
            Assert.IsTrue(Logic1.IsHilly(132));
            Assert.IsTrue(Logic1.IsHilly(1234642));
            Assert.IsTrue(Logic1.IsHilly(1357743));
            Assert.IsFalse(Logic1.IsHilly(1435421));
            Assert.IsFalse(Logic1.IsHilly(3454326));
            Assert.IsTrue(Logic1.IsHilly(35782));
        }

        [Test]
        [Category("Selection")]
        public void CloseFar()
        {

            Assert.AreEqual(true, Logic1.CloseFar(1, 2, 10));
            Assert.AreEqual(false, Logic1.CloseFar(1, 2, 3));
            Assert.AreEqual(true, Logic1.CloseFar(4, 1, 3));
            Assert.AreEqual(false, Logic1.CloseFar(4, 5, 3));
            Assert.AreEqual(false, Logic1.CloseFar(4, 3, 5));
            Assert.AreEqual(true, Logic1.CloseFar(-1, 10, 0));
            Assert.AreEqual(true, Logic1.CloseFar(0, -1, 10));
            Assert.AreEqual(true, Logic1.CloseFar(10, 10, 8));
            Assert.AreEqual(false, Logic1.CloseFar(10, 8, 9));
            Assert.AreEqual(false, Logic1.CloseFar(8, 9, 10));
            Assert.AreEqual(false, Logic1.CloseFar(8, 9, 7));
            Assert.AreEqual(true, Logic1.CloseFar(8, 6, 9));
        }
    }
}
