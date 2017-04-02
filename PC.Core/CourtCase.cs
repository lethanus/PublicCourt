using System;

namespace PC.Core
{
    public class CourtCase
    {
        private DateTime inputDate;
        private DateTime originalInputDate;

        public CourtCase(DateTime inputDate)
        {
            this.InputDate = inputDate;
            this.originalInputDate = inputDate;
        }

        public CourtCase(DateTime inputDate, DateTime originalInputDate) : this(inputDate)
        {
            this.OriginalInputDate = originalInputDate;
        }

        public DateTime InputDate { get => inputDate; set => inputDate = value; }
        public DateTime OriginalInputDate { get => originalInputDate; set => originalInputDate = value; }

    }
}