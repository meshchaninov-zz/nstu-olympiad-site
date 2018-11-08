using System;

namespace nstu_olympiad_site.Models
{
    public class CheckLog
    {
         public int Id { get; set; }
        public int SolutionId { get; set; }
        public int CheckResultCode { get; set; }
        public string Log { get; set; }
        public DateTime CheckTime { get; set; }

        public virtual Solution Solution { get; set; }
    }
}