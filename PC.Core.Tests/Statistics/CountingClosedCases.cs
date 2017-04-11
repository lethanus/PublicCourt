using System;
using Xunit;
using PC.Core;
using System.Linq;
using PC.Core.Tests.Statistics.Utils;

namespace PC.Core.Tests.Statistics
{
    public class CountingClosedCases
    {
        [Theory]
        [InlineData("2017-12-31", "2017-02-01", "2017-03-22", 1, StatisticType.Closed)]
        [InlineData("2016-12-31", "2016-02-01", "2017-03-22", 0, StatisticType.Closed)]
        [InlineData("2017-12-31", "2015-02-01", "2016-03-22", 1, StatisticType.Closed)]
        [InlineData("2017-12-31", "2015-02-01", "2016-03-22", 0, StatisticType.ClosedThisYear)]
        [InlineData("2017-12-31", "2015-02-01", "2017-03-22", 1, StatisticType.ClosedThisYear)]
        [InlineData("2016-12-31", "2015-02-01", "2017-03-22", 0, StatisticType.ClosedThisYear)]
        [InlineData("2017-12-31", "2015-02-01", "2017-03-22", 1, StatisticType.ClosedThisYearFromPreviousYears)]
        [InlineData("2016-12-31", "2016-02-01", "2016-03-22", 0, StatisticType.ClosedThisYearFromPreviousYears)]
        [InlineData("2017-12-31", "2015-02-01", "2016-03-22", 0, StatisticType.ClosedThisYearFromPreviousYears)]
        public void ClosedCourtCaseShouldAppearInStatistics(string statisticDateString,
            string inputDateString, string closeDateString, int expectedValue,
            StatisticType statisticType)
        {
            var statisticDate = DateTime.Parse(statisticDateString);
            var inputDate = DateTime.Parse(inputDateString);
            var closeDate = DateTime.Parse(closeDateString);
            var courtCase = CourtCaseBuilder.BuildCourtCase(inputDate, inputDate, closeDate);

            StatisticVerification.TestStatistic(courtCase, statisticDate, expectedValue, statisticType);
        }
    }
}
