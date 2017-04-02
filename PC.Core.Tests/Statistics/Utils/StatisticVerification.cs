using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PC.Core.Tests.Statistics.Utils
{
    public class StatisticVerification
    {

        public static void AddCaseAndCheckStatistics(StatisitcType statisticType, RepertoryStatistics repertoryStatistics, CourtCaseRepertory courtCaseRepertory, CourtCase courtCase)
        {
            VerifyStatisitcValue(statisticType, repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year - 1);
            VerifyStatisitcValue(statisticType, repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year);
            VerifyStatisitcValue(statisticType, repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year + 1);

            courtCaseRepertory.Add(courtCase);

            VerifyStatisitcValue(statisticType, repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year - 1);
            VerifyStatisitcValue(statisticType, repertoryStatistics, courtCaseRepertory, 1, courtCase.InputDate.Year);
            VerifyStatisitcValue(statisticType, repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year + 1);
        }

        private static void VerifyStatisitcValue(StatisitcType statisticType, RepertoryStatistics repertoryStatistics, CourtCaseRepertory courtCaseRepertory, int expected, int statisticYear)
        {
            Assert.Equal(expected, repertoryStatistics.GetStatisticValue(statisticType, courtCaseRepertory, statisticYear));
        }
    }
}
