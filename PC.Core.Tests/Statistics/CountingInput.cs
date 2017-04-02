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

            Assert.Equal(courtCase.InputDate, courtCase.OriginalInputDate);
        }

        [Fact]
        public void NewReopenedCourtCaseShouldAppearInStatistics()
        {
            var originalInputDate = new DateTime(2015, 4, 1);
            var inputDate = new DateTime(2017, 4, 1);
            var courtCase = new CourtCase(inputDate, originalInputDate);
            var courtCaseRepertory = new CourtCaseRepertory();
            var repertoryStatistics = new RepertoryStatistics();

            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2016));
            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2017));
            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2018));

            courtCaseRepertory.Add(courtCase);

            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2016));
            Assert.Equal(1, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2017));
            Assert.Equal(0, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, 2018));

            Assert.NotEqual(courtCase.InputDate, courtCase.OriginalInputDate);
        }
    }
}
