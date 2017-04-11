using System;

namespace PC.Core
{
    public class CourtCase
    {
        private readonly DateTime inputDate;
        private readonly DateTime originalInputDate;
        private DateTime? closeDate;

        public CourtCase(DateTime inputDate)
        {
            this.inputDate = inputDate;
            this.originalInputDate = inputDate;
        }

        public CourtCase(DateTime inputDate, DateTime originalInputDate) : this(inputDate)
        {
            this.originalInputDate = originalInputDate;
        }

        public void CloseCase(DateTime closeDate)
        {
            this.closeDate = closeDate;
        }

        public DateTime InputDate { get { return inputDate; } }
        public DateTime OriginalInputDate { get { return originalInputDate; } }
        public DateTime? CloseDate { get { return closeDate; } }
    }
}