using System;
using System.Collections.Generic;
using System.Linq;

namespace PC.Core
{
    public enum StatisticType { Input, Closed, Open, OpenFromPreviousYears, ClosedThisYear };
    public class RepertoryStatistics
    {
        private DateTime statisticDate;
        private StatisticType statisitcType;
        public RepertoryStatistics(DateTime statisticDate, StatisticType statisitcType)
        {
            this.statisticDate = statisticDate;
            this.statisitcType = statisitcType;
        }

        public int GetStatisticValue(CourtCaseRepertory courtCaseRepertory)
        {
            switch(statisitcType)
            {
                case StatisticType.Input:
                    return ThisYearCases(courtCaseRepertory).Count();
                case StatisticType.Closed:
                    return ClosedCases(courtCaseRepertory).Count();
                case StatisticType.Open:
                    return OpenCasesBeforeDate(courtCaseRepertory).Count();
                case StatisticType.OpenFromPreviousYears:
                    return OpenCasesFromPreviousYears(courtCaseRepertory).Count();
                case StatisticType.ClosedThisYear:
                    return ClosedThisYear(courtCaseRepertory).Count();
                default:
                    return -1;
            }
        }

        private IEnumerable<CourtCase> ThisYearCases(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Where(c => c.InputDate.Year == statisticDate.Year);
        }

        private IEnumerable<CourtCase> ClosedCases(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate.HasValue && c.CloseDate.Value <= statisticDate);
        }

        private IEnumerable<CourtCase> ClosedThisYear(CourtCaseRepertory courtCaseRepertory)
        {
            return ClosedCases(courtCaseRepertory).Where(c => c.CloseDate.Value.Year == statisticDate.Year);
        }

        private IEnumerable<CourtCase> OpenCases(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate == null);
        }

        private IEnumerable<CourtCase> OpenCasesBeforeDate(CourtCaseRepertory courtCaseRepertory)
        {
            return OpenCases(courtCaseRepertory).Where(c => c.InputDate <= statisticDate);
        }

        private IEnumerable<CourtCase> OpenCasesFromPreviousYears(CourtCaseRepertory courtCaseRepertory)
        {
            return OpenCases(courtCaseRepertory).Where(c => c.OriginalInputDate.Year < statisticDate.Year);
        }

    }
}