using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PC.Core.Tests.Statistics.Utils
{
    public class StatisticVerification
    {
        public static void TestStatistic(CourtCase courtCase, DateTime statisticDate, int expectedValue, StatisticType statisticType)
        {
            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics(statisticDate, statisticType);

            CheckStatistics(0, repertoryStatistics, courtCaseRepertory);
            courtCaseRepertory.Add(courtCase);
            CheckStatistics(expectedValue, repertoryStatistics, courtCaseRepertory);
        }

        private static void CheckStatistics(int expectedValue, RepertoryStatistics repertoryStatistics, CourtCaseRepertory courtCaseRepertory)
        {
            Assert.Equal(expectedValue, repertoryStatistics.GetStatisticValue(courtCaseRepertory));
        }
    }
}
