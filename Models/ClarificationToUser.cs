using System;

namespace nstu_olympiad_site.Models
{
    public class ClarificationToUser : Clarification
    {
        public string QuestionText { get; set; }
        public DateTime? QuestionTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}