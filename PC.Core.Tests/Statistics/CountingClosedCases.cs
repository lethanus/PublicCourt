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
            var courtCase = new CourtCase(inputDate);
            courtCase.CloseCase(closeDate);

            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            StatisticVerification.CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            StatisticVerification.CheckStatistics(1, repertoryStatistics, courtCaseRepertory);
        }
    }
}
