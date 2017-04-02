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
            var statisticType = StatisitcType.Closed;
            var inputDate = new DateTime(2017, 2, 1);
            var closeDate = new DateTime(2017, 3, 22);
            var courtCase = new CourtCase(inputDate);
            courtCase.CloseCase(closeDate);

            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics();

            StatisticVerification.AddCaseAndCheckStatistics(statisticType, repertoryStatistics, courtCaseRepertory, courtCase);
        }
    }
}
