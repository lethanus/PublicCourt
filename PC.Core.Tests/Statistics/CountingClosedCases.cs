using System;
using Xunit;
using PC.Core;
using System.Linq;
using PC.Core.Tests.Statistics.Utils;

namespace PC.Core.Tests.Statistics
{
    public class CountingClosedCases
    {
        [Fact]
        public void ClosedCourtCaseShouldAppearInStatistics()
        {
            var statisticType = StatisticType.Closed;
            var statisticDate = new DateTime(2017, 12, 31);
            var inputDate = new DateTime(2017, 2, 1);
            var closeDate = new DateTime(2017, 3, 22);
            var courtCase = CourtCaseBuilder.BuildCourtCase(inputDate, inputDate, closeDate);

            StatisticVerification.TestStatistic(courtCase, statisticDate, 1, statisticType);
        }
    }
}
