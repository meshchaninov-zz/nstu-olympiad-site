using System;

namespace nstu_olympiad_site.Models
{
    public class Clarification
    {
        public int Id { get; set; }
        
        public string Text { get; set; }
        public DateTime? PublishTime { get; set; }

        public int? ContestId { get; set; }
        public virtual Contest Contest { get; set; }

        public int? ProblemId { get; set; }
        public virtual Problem Problem { get; set; }
    }

    //TODO: ClarificationToUser?
}