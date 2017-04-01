using System;
using System.Collections.Generic;

namespace PC.Core.Tests
{
    public class RepertoryStatistics
    {
        public RepertoryStatistics()
        {
        }

        public int GetAmountOfNewCases(CourtCaseRepertory courtCaseRepertory)
        {
            return courtCaseRepertory.Cases.Count;
        }
    }
}