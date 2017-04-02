using System;
using Xunit;
using PC.Core;
using System.Linq;

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

            AddNewCaseAndCheckStatistics(repertoryStatistics, courtCaseRepertory, courtCase);

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

            AddNewCaseAndCheckStatistics(repertoryStatistics, courtCaseRepertory, courtCase);

            Assert.NotEqual(courtCase.InputDate, courtCase.OriginalInputDate);
        }

        private void AddNewCaseAndCheckStatistics(RepertoryStatistics repertoryStatistics, CourtCaseRepertory courtCaseRepertory, CourtCase courtCase)
        {
            VerifyAmountOfNewCases(repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year - 1);
            VerifyAmountOfNewCases(repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year);
            VerifyAmountOfNewCases(repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year + 1);

            courtCaseRepertory.Add(courtCase);

            VerifyAmountOfNewCases(repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year - 1);
            VerifyAmountOfNewCases(repertoryStatistics, courtCaseRepertory, 1, courtCase.InputDate.Year);
            VerifyAmountOfNewCases(repertoryStatistics, courtCaseRepertory, 0, courtCase.InputDate.Year + 1);
        }

        private void VerifyAmountOfNewCases(RepertoryStatistics repertoryStatistics, CourtCaseRepertory courtCaseRepertory, int expected, int statisticYear)
        {
            Assert.Equal(expected, repertoryStatistics.GetAmountOfNewCases(courtCaseRepertory, statisticYear));
        }
    }
}
