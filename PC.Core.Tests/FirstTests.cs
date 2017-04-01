using System;
using Xunit;
using PC.Core;

namespace PC.Core.Tests
{
    public class FirstTests
    {
        [Fact]
        public void NewCourtCaseShoudAppearInStatistics()
        {
            var courtCase = new CourtCase();
            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics();

            Assert.Equal(0,repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory));

            courtCaseRepertory.Add(courtCase);

            Assert.Equal(1, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory));

        }
    }
}
