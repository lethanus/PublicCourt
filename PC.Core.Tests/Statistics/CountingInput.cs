using System;
using Xunit;
using PC.Core;
using System.Linq;
using PC.Core.Tests.Statistics.Utils;

namespace PC.Core.Tests.Statistics
{
    public class CountingInput
    {
        [Theory]
        [InlineData("2017-12-31", "2017-04-01", 1, StatisticType.Input)]
        public void NewCourtCaseShouldAppearInStatistics(string statisticDateString, string inputDateString, int expectedValue, StatisticType statisticType)
        {
            var statisticDate = DateTime.Parse(statisticDateString);
            var inputDate = DateTime.Parse(inputDateString);
            var courtCase = CourtCaseBuilder.BuildCourtCase(inputDate);

            StatisticVerification.TestStatistic(courtCase, statisticDate, 1, statisticType);
            Assert.Equal(courtCase.InputDate, courtCase.OriginalInputDate);
        }

        [Theory]
        [InlineData("2017-12-31", "2017-04-01", "2015-04-01", 1, StatisticType.Input)]
        public void NewReopenedCourtCaseShouldAppearInStatistics(string statisticDateString, string inputDateString, string originalInputDateString, int expectedValue, StatisticType statisticType)
        {
            var statisticDate = DateTime.Parse(statisticDateString);
            var inputDate = DateTime.Parse(inputDateString);
            var originalInputDate = DateTime.Parse(originalInputDateString);
            var courtCase = CourtCaseBuilder.BuildCourtCase(inputDate, originalInputDate);

            StatisticVerification.TestStatistic(courtCase, statisticDate, expectedValue, statisticType);
            Assert.NotEqual(courtCase.InputDate, courtCase.OriginalInputDate);
        }

    }
}
