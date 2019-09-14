﻿using NBi.Core.Transformation.Transformer;
using NBi.Core.Transformation.Transformer.Native;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Testing.Core.Transformation.Transformer
{
    [TestFixture]
    public class DateToPointInTimeTest
    {
        [Test]
        [TestCase("2018-02-01 00:00:00", "2018-02-01")]
        [TestCase("2018-02-01 07:00:00", "2018-02-01")]
        [TestCase("2018-02-12 07:00:00", "2018-02-01")]
        public void Execute_DateTimeToFirstOfMonth_Valid(string value, DateTime expected)
        {
            var function = new DateTimeToFirstOfMonth();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2018-02-01 00:00:00", "2018-01-01")]
        [TestCase("2018-02-01 07:00:00", "2018-01-01")]
        [TestCase("2018-02-12 07:00:00", "2018-01-01")]
        public void Execute_DateTimeToFirstOfYear_Valid(string value, DateTime expected)
        {
            var function = new DateTimeToFirstOfYear();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2018-02-01 00:00:00", "2018-02-28")]
        [TestCase("2018-02-01 07:00:00", "2018-02-28")]
        [TestCase("2018-02-12 07:00:00", "2018-02-28")]
        public void Execute_DateTimeToLastOfMonth_Valid(string value, DateTime expected)
        {
            var function = new DateTimeToLastOfMonth();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2018-02-01 00:00:00", "2018-12-31")]
        [TestCase("2018-02-01 07:00:00", "2018-12-31")]
        [TestCase("2018-02-12 07:00:00", "2018-12-31")]
        public void Execute_DateTimeToLastOfYear_Valid(string value, DateTime expected)
        {
            var function = new DateTimeToLastOfYear();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11", "2019-03-11")]
        [TestCase("2019-02-11", "2019-03-01")]
        [TestCase("2019-04-11", "2019-03-31")]
        public void Execute_DateTimeToClip_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToClip("2019-03-01", "2019-03-31");
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11", "2019-03-12")]
        [TestCase("2019-02-11", "2019-02-12")]
        [TestCase("2019-03-31", "2019-04-01")]
        public void Execute_DateTimeToNextDay_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToNextDay();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11", "2019-04-11")]
        [TestCase("2019-03-31", "2019-04-30")]
        [TestCase("2020-01-31", "2020-02-29")]
        public void Execute_DateTimeToNextMonth_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToNextMonth();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11", "2020-03-11")]
        [TestCase("2020-02-29", "2021-02-28")]
        public void Execute_DateTimeToNextYear_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToNextYear();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11", "2019-03-10")]
        [TestCase("2019-02-01", "2019-01-31")]
        [TestCase("2020-03-01", "2020-02-29")]
        [TestCase("2020-03-01 17:30:12", "2020-02-29 17:30:12")]
        public void Execute_DateTimeToPreviousDay_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToPreviousDay();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11", "2019-02-11")]
        [TestCase("2019-03-31", "2019-02-28")]
        [TestCase("2020-01-31", "2019-12-31")]
        [TestCase("2020-01-31 17:30:12", "2019-12-31 17:30:12")]
        public void Execute_DateTimeToPreviousMonth_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToPreviousMonth();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11", "2018-03-11")]
        [TestCase("2020-02-29", "2019-02-28")]
        public void Execute_DateTimeToPreviousYear_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToPreviousYear();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11 12:00:00", "07:00:00", "2019-03-11 07:00:00")]
        [TestCase("2019-02-11 08:45:12", "07:13:11", "2019-02-11 07:13:11")]
        public void Execute_DateTimeToSetTime_Valid(object value, string instant, DateTime expected)
        {
            var function = new DateTimeToSetTime(instant);
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11 17:00:00", "2019-03-11 17:00:00")]
        [TestCase("2019-03-11 17:20:00", "2019-03-11 17:00:00")]
        [TestCase("2019-03-11 17:20:24", "2019-03-11 17:00:00")]
        [TestCase("2019-03-11 17:40:00", "2019-03-11 17:00:00")]
        public void Execute_DateTimeToFloorHour_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToFloorHour();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11 17:00:00", "2019-03-11 17:00:00")]
        [TestCase("2019-03-11 17:20:00", "2019-03-11 18:00:00")]
        [TestCase("2019-03-11 17:20:24", "2019-03-11 18:00:00")]
        [TestCase("2019-03-11 17:40:00", "2019-03-11 18:00:00")]
        public void Execute_DateTimeToCeilingHour_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToCeilingHour();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11 17:00:00", "2019-03-11 17:00:00")]
        [TestCase("2019-03-11 17:20:00", "2019-03-11 17:20:00")]
        [TestCase("2019-03-11 17:20:24.120", "2019-03-11 17:20:00")]
        [TestCase("2019-03-11 17:40:59", "2019-03-11 17:40:00")]
        public void Execute_DateTimeToFloorMinute_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToFloorMinute();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11 17:00:00", "2019-03-11 17:00:00")]
        [TestCase("2019-03-11 17:20:00", "2019-03-11 17:20:00")]
        [TestCase("2019-03-11 17:20:24.120", "2019-03-11 17:21:00")]
        [TestCase("2019-03-11 17:59:59", "2019-03-11 18:00:00")]
        public void Execute_DateTimeToCeilingMinute_Valid(object value, DateTime expected)
        {
            var function = new DateTimeToCeilingMinute();
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("2019-03-11 17:00:00", 0, "04:00:00", "2019-03-11 17:00:00")]
        [TestCase("2019-03-11 17:00:00", 1, "04:00:00", "2019-03-11 21:00:00")]
        [TestCase("2019-03-11 17:00:00", 2, "04:00:00", "2019-03-12 01:00:00")]
        [TestCase("2019-03-11 17:00:00", -1, "04:00:00", "2019-03-11 13:00:00")]
        public void Execute_DateTimeToAdd_Valid(object value, int times, string timeSpan, DateTime expected)
        {
            var function = new DateTimeToAdd(timeSpan, times.ToString());
            var result = function.Evaluate(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}