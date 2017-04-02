using System;
using Xunit;
using PC.Core;
using System.Linq;

namespace PC.Core.Tests.Statistics
{
    public class CountingClosedCases
    {
        [Fact]
        public void ClosedCourtCaseShouldAppearInStatistics()
        {
            var inputDate = new DateTime(2017, 2, 1);
            var closeDate = new DateTime(2017, 3, 22);
            var courtCase = new CourtCase(inputDate);
            courtCase.CloseCase(closeDate);

            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics();

            Assert.Equal(0, repertoryStatistics.GetAmountOfClosedCases(courtCaseRepertory, 2017));
            courtCaseRepertory.Add(courtCase);
            Assert.Equal(1, repertoryStatistics.GetAmountOfClosedCases(courtCaseRepertory, 2017));

        }
    }
}
