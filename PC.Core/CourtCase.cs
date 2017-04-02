using System;

namespace PC.Core
{
    public class CourtCase
    {
        private DateTime inputDate;

        public CourtCase(DateTime inputDate)
        {
            this.inputDate = inputDate;
        }

        public int InputYear
        {
            get { return inputDate.Year; }
        }
    }
}