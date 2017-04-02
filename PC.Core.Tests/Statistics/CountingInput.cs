using System;
using Xunit;
using PC.Core;
using System.Linq;
using PC.Core.Tests.Statistics.Utils;

namespace PC.Core.Tests.Statistics
{
    public class CountingInput
    {
        [Fact]
        public void NewCourtCaseShouldAppearInStatistics()
        {
            var statisticDate = new DateTime(2017, 12, 31);
            var statisticType = StatisticType.Input;
            var inputDate = new DateTime(2017, 4, 1);
            var courtCase = CourtCaseBuilder.BuildCourtCase(inputDate);

            StatisticVerification.TestStatistic(courtCase, statisticDate, 1, statisticType);
            Assert.Equal(courtCase.InputDate, courtCase.OriginalInputDate);
        }

        [Fact]
        public void NewReopenedCourtCaseShouldAppearInStatistics()
        {
            var statisticDate = new DateTime(2017, 12, 31);
            var statisticType = StatisticType.Input;
            var originalInputDate = new DateTime(2015, 4, 1);
            var inputDate = new DateTime(2017, 4, 1);
            var courtCase = CourtCaseBuilder.BuildCourtCase(inputDate, originalInputDate);

            StatisticVerification.TestStatistic(courtCase, statisticDate, 1, statisticType);
            Assert.NotEqual(courtCase.InputDate, courtCase.OriginalInputDate);
        }

    }
}
