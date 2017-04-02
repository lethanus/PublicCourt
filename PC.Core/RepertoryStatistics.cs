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
            return courtCaseRepertory.Cases.Where(c => c.InputYear == statisticYear).Count();
        }

    }
}