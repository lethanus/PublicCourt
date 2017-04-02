using System;
using System.Collections.Generic;
using System.Linq;

namespace PC.Core
{
    public enum StatisitcType { Input, Closed };
    public class RepertoryStatistics
    {
        public RepertoryStatistics()
        {
        }

        public int GetStatisticValue(StatisitcType statisitcType, CourtCaseRepertory courtCaseRepertory, int statisticYear)
        {
            switch(statisitcType)
            {
                case StatisitcType.Input:
                    return GetAmountOfNewCases(courtCaseRepertory, statisticYear);
                case StatisitcType.Closed:
                    return GetAmountOfClosedCases(courtCaseRepertory, statisticYear);
                default:
                    return -1;
            }
        }

        private int GetAmountOfNewCases(CourtCaseRepertory courtCaseRepertory, int statisticYear)
        {
            return courtCaseRepertory.Cases.Where(c => c.InputDate.Year == statisticYear).Count();
        }

        private int GetAmountOfClosedCases(CourtCaseRepertory courtCaseRepertory, int statisticYear)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate.Year == statisticYear).Count();
        }
    }
}