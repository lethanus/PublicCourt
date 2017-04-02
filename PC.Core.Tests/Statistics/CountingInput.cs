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
            var statisticType = StatisitcType.Input;
            var inputDate = new DateTime(2017, 4, 1);
            var courtCase = new CourtCase(inputDate);
            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            StatisticVerification.CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            StatisticVerification.CheckStatistics(1, repertoryStatistics, courtCaseRepertory);

            Assert.Equal(courtCase.InputDate, courtCase.OriginalInputDate);
        }

        [Fact]
        public void NewReopenedCourtCaseShouldAppearInStatistics()
        {
            var statisticDate = new DateTime(2017, 12, 31);
            var statisticType = StatisitcType.Input;
            var originalInputDate = new DateTime(2015, 4, 1);
            var inputDate = new DateTime(2017, 4, 1);
            var courtCase = new CourtCase(inputDate, originalInputDate);
            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            StatisticVerification.CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            StatisticVerification.CheckStatistics(1, repertoryStatistics, courtCaseRepertory);

            Assert.NotEqual(courtCase.InputDate, courtCase.OriginalInputDate);
        }

    }
}
