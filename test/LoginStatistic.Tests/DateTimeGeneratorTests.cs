using System;
using System.Collections.Generic;
using Xunit;

namespace LoginStatistic.Tests
{
    public class DateTimeGeneratorTests
    {
        [Fact]
        public void Next_Correctness()
        {
            DateTimeGenerator dateGenerator = new DateTimeGenerator();

            List<DateTime> results = new List<DateTime>();
            for (int i = 0; i < 3; i++)
            {
                results.Add(dateGenerator.Next());
            }

            Assert.True(results[0] < results[1]);
            Assert.True(results[1] < results[2]);
            Assert.InRange(results[0], new DateTime(2016, 1, 1), DateTime.Now);
            Assert.InRange(results[1], new DateTime(2016, 1, 1), DateTime.Now);
            Assert.InRange(results[2], new DateTime(2016, 1, 1), DateTime.Now);
        }
    }
}
