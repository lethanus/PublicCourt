using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PC.Core.Tests.Statistics.Utils
{
    public class StatisticVerification
    {

        public static void CheckStatistics(int expectedValue, RepertoryStatistics repertoryStatistics, CourtCaseRepertory courtCaseRepertory)
        {
            Assert.Equal(expectedValue, repertoryStatistics.GetStatisticValue(courtCaseRepertory));
        }
    }
}
