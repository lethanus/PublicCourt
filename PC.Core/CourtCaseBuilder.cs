using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Core
{
    public class CourtCaseBuilder
    {
        public static CourtCase BuildCourtCase(DateTime inputDate, DateTime originalInputDate, DateTime? closeDate)
        {
            CourtCase courtCase = BuildCourtCase(inputDate, originalInputDate);
            if (closeDate != null) courtCase.CloseCase(closeDate.Value);
            return courtCase;
        }

        public static CourtCase BuildCourtCase(DateTime inputDate, DateTime originalInputDate)
        {
            return inputDate > originalInputDate ? new CourtCase(inputDate, originalInputDate) : BuildCourtCase(inputDate);
        }

        public static CourtCase BuildCourtCase(DateTime inputDate)
        {
            return new CourtCase(inputDate);
        }

    }
}
