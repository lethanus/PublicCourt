using System;
using System.Collections.Generic;
using System.Linq;

namespace PC.Core
{
    public class RepertoryStatistics
    {
        public RepertoryStatistics()
        {
        }

        public int GetAmountOfNewCases(CourtCaseRepertory courtCaseRepertory, int statisticYear)
        {
            return courtCaseRepertory.Cases.Where(c => c.InputDate.Year == statisticYear).Count();
        }

        public int GetAmountOfClosedCases(CourtCaseRepertory courtCaseRepertory, int statisticYear)
        {
            return courtCaseRepertory.Cases.Where(c => c.CloseDate.Year == statisticYear).Count();
        }
    }
}