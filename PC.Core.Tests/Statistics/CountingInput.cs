using System;
using Xunit;
using PC.Core;

namespace PC.Core.Tests.CountingInput
{
    public class CountingInput
    {
        [Fact]
        public void NewCourtCaseShouldAppearInStatistics()
        {
            var inputDate = new DateTime(2017, 4, 1);
            var courtCase = new CourtCase(inputDate);
            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics();

            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2016));
            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2017));
            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2018));

            courtCaseRepertory.Add(courtCase);

            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2016));
            Assert.Equal(1, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2017));
            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2018));

        }
    }
}
