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
        [InlineData("2017-12-31", "2017-02-01", 1, StatisticType.Open)]
        [InlineData("2016-12-31", "2017-02-01", 0, StatisticType.Open)]
        [InlineData("2017-12-31", "2015-02-01", 1, StatisticType.Open)]
        public void OpenCourtCaseShouldAppearInStatistics(string statisticDateString, string inputDateString, int expectedValue, StatisticType statisticType)
        {
            var statisticDate = DateTime.Parse(statisticDateString);
            var inputDate = DateTime.Parse(inputDateString);
            var courtCase = new CourtCase(inputDate);

            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            StatisticVerification.CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            StatisticVerification.CheckStatistics(expectedValue, repertoryStatistics, courtCaseRepertory);
        }


        [Theory]
        [InlineData("2017-12-31", "2017-02-01", "2016-02-01", 1, StatisticType.OpenFromPreviousYears)]
        [InlineData("2016-12-31", "2017-02-01", "2016-02-01", 0, StatisticType.OpenFromPreviousYears)]
        [InlineData("2017-12-31", "2015-02-01", "2015-01-13", 1, StatisticType.OpenFromPreviousYears)]
        public void OpenCourtCaseFromPreviousYearShouldAppearInStatistics(string statisticDateString, string inputDateString, string originalInputDateString, int expectedValue, StatisticType statisticType)
        {
            var statisticDate = DateTime.Parse(statisticDateString);
            var inputDate = DateTime.Parse(inputDateString);
            var originalInputDate = DateTime.Parse(originalInputDateString);
            var courtCase = new CourtCase(inputDate, originalInputDate);

            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            StatisticVerification.CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            StatisticVerification.CheckStatistics(expectedValue, repertoryStatistics, courtCaseRepertory);
        }
    }
}
