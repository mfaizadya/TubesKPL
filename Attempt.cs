using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesKPL
{
    class Attempt
    {
        public int AttemptId { get; set; }
        public string UserName { get; set; }
        public string Level { get; set; }
        public double Score { get; set; }
        public DateTime AttemptDate { get; set; }

        public Attempt(int attemptId, string userName, string level, double score, DateTime attemptDate)
        {
            AttemptId = attemptId;
            UserName = userName;
            Level = level;
            Score = score;
            AttemptDate = attemptDate;
        }
    }
}
