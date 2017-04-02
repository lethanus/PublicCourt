using System;
using Xunit;
using PC.Core;
using System.Linq;
using PC.Core.Tests.Statistics.Utils;

namespace PC.Core.Tests.Statistics
{
    public class CountingOpenCases
    {
        [Theory]
        [InlineData("2017-12-31", "2017-02-01", 1)]
        [InlineData("2016-12-31", "2017-02-01", 0)]
        [InlineData("2017-12-31", "2015-02-01", 1)]
        public void OpenCourtCaseShouldAppearInStatistics(string statisticDateString, string inputDateString, int expectedValue)
        {
            var statisticDate = DateTime.Parse(statisticDateString);
            var statisticType = StatisitcType.Open;
            var inputDate = DateTime.Parse(inputDateString);
            var courtCase = new CourtCase(inputDate);

            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            StatisticVerification.CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            StatisticVerification.CheckStatistics(expectedValue, repertoryStatistics, courtCaseRepertory);
        }


        [Fact]
        public void OpenCourtCaseFromPreviousYearShouldAppearInStatistics()
        {
            var statisticDate = new DateTime(2017, 12, 31);
            var statisticType = StatisitcType.OpenFromPreviousYears;
            var inputDate = new DateTime(2017, 2, 1);
            var originalInputDate = new DateTime(2015, 4, 1);
            var courtCase = new CourtCase(inputDate, originalInputDate);

            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            StatisticVerification.CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            StatisticVerification.CheckStatistics(1, repertoryStatistics, courtCaseRepertory);
        }
    }
}
