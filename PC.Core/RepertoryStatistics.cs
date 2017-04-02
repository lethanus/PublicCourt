using System;
using System.Collections.Generic;
using System.Linq;

namespace PC.Core
{
    public enum StatisitcType { Input, Closed, Open };
    public class RepertoryStatistics
    {
        public RepertoryStatistics()
        {
        }

        public int GetStatisticValue(StatisitcType statisitcType, CourtCaseRepertory courtCaseRepertory, DateTime statisticDate)
        {
            switch(statisitcType)
            {
                case StatisitcType.Input:
                    return NewCases(courtCaseRepertory, statisticDate).Count();
                case StatisitcType.Closed:
                    return ClosedCases(courtCaseRepertory, statisticDate).Count();
                case StatisitcType.Open:
                    return OpenCases(courtCaseRepertory, statisticDate).Count();
                default:
                    return -1;
            }
        }

        private IEnumerable<CourtCase> NewCases(CourtCaseRepertory courtCaseRepertory, DateTime statisticDate)
        {
            return courtCaseRepertory.Cases.Where(c => c.InputDate.Year == statisticDate.Year);
        }

        private IEnumerable<CourtCase> ClosedCases(CourtCaseRepertory courtCaseRepertory, DateTime statisticDate)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate.HasValue && c.CloseDate.Value.Year == statisticDate.Year);
        }

        private IEnumerable<CourtCase> OpenCases(CourtCaseRepertory courtCaseRepertory, DateTime statisticYear)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate == null);
        }
    }
}