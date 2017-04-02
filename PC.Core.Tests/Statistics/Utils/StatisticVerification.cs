using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PC.Core.Tests.Statistics.Utils
{
    public class StatisticVerification
    {

        public static void CheckStatistics(int expectedValue, StatisitcType statisticType, RepertoryStatistics repertoryStatistics, CourtCaseRepertory courtCaseRepertory, DateTime statisticDate)
        {
            Assert.Equal(expectedValue, repertoryStatistics.GetStatisticValue(statisticType, courtCaseRepertory, statisticDate));
        }
    }
}
