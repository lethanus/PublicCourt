using System;
using System.Collections.Generic;
using System.Linq;

namespace PC.Core
{
    public enum StatisitcType { Input, Closed, Open, OpenFromPreviousYears };
    public class RepertoryStatistics
    {
        private DateTime statisticDate;
        private StatisitcType statisitcType;
        public RepertoryStatistics(DateTime statisticDate, StatisitcType statisitcType)
        {
            this.statisticDate = statisticDate;
            this.statisitcType = statisitcType;
        }

        public int GetStatisticValue(CourtCaseRepertory courtCaseRepertory)
        {
            switch(statisitcType)
            {
                case StatisitcType.Input:
                    return NewCases(courtCaseRepertory).Count();
                case StatisitcType.Closed:
                    return ClosedCases(courtCaseRepertory).Count();
                case StatisitcType.Open:
                    return OpenCases(courtCaseRepertory).Count();
                case StatisitcType.OpenFromPreviousYears:
                    return OpenCasesFromPreviousYears(courtCaseRepertory).Count();
                default:
                    return -1;
            }
        }

        private IEnumerable<CourtCase> NewCases(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Where(c => c.InputDate.Year == statisticDate.Year);
        }

        private IEnumerable<CourtCase> ClosedCases(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate.HasValue && c.CloseDate.Value.Year == statisticDate.Year);
        }

        private IEnumerable<CourtCase> OpenCases(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate == null);
        }
        private IEnumerable<CourtCase> OpenCasesFromPreviousYears(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate == null && c.InputDate > c.OriginalInputDate);
        }

    }
}