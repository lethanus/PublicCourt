using System;
using System.Collections.Generic;

namespace PC.Core
{
    public class CourtCaseRepertory
    {
        private List<CourtCase> cases = new List<CourtCase>();
        public CourtCaseRepertory()
        {
        }

        public ICollection<CourtCase> Cases
        {
            get { return cases; }
        }

        public void Add(CourtCase courtCase)
        {
            cases.Add(courtCase);
        }
    }
}