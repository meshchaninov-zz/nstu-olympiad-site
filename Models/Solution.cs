using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Reflection;
using nstu_olympiad_site.Utils;

namespace nstu_olympiad_site.Models
{
    public class Solution
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        [Display(Name = "Пользователь")]
        public virtual User User { get; set; }

        public int ProblemId { get; set; }
        [Display(Name = "Задача")]
        public virtual Problem Problem { get; set; }

        public int CompilatorId { get; set; }
        [Display(Name = "Компилятор")]
        public virtual Compilator Compilator { get; set; }

        [Display(Name = "Время отправки")]
        public DateTime CommitTime { get; set; }
        public string CommiterInfo { get; set; }

        [Required]
        public virtual byte[] SourceCode { get; set; }

        public int StatusCode { get; set; }
        public bool Hidden { get; set; }
        public bool Reference { get; set; }
        public string Description { get; set; }

        [Display(Name = "Макс. время")]
        public TimeSpan? MaxUserTime { get; set; }

        [Display(Name = "Макс. память")]
        public int? MaxMemory { get; set; }

        public DateTime LastCheck { get; set; }

        public string OldStatusText
        {
            get
            {
                if (StatusCode == 0)
                    return "В очереди...";
                if (StatusCode == 1)
                    return "На проверке...";
                if (StatusCode == 2)
                    return "OK";
                if (StatusCode == -1)
                    return "Ошибка компиляции";
                if (StatusCode < -1000 && StatusCode > -2000)
                    return "Неправильный ответ на тесте " + (-StatusCode - 1000).ToString();
                if (StatusCode < -2000 && StatusCode > -3000)
                    return "Превышение лимита времени на тесте " + (-StatusCode - 2000).ToString();
                if (StatusCode < -3000 && StatusCode > -4000)
                    return "Ошибка выполнения на тесте " + (-StatusCode - 3000).ToString();
                if (StatusCode < -4000 && StatusCode > -5000)
                    return "Ошибка выполнения на тесте " + (-StatusCode - 4000).ToString();
                if (StatusCode < -5000 && StatusCode > -6000)
                    return "Превышение лимита времени на тесте " + (-StatusCode - 5000).ToString();
                if (StatusCode < -6000 && StatusCode > -7000)
                    return "Превышение ограничений по памяти на тесте " + (-StatusCode - 6000).ToString();
                return "Внутренняя ошибка системы";
            }
        }
    //TODO: ???? 
        public string StatusText
        {
            get
            {
                return StatusState.GetAttribute<DisplayAttribute>().Name + (StatusTestNumber.HasValue ? " на тесте " + StatusTestNumber : "");
            }
        }

        public string ShortStatusText
        {
            get
            {
                return StatusState.GetAttribute<DisplayAttribute>().ShortName + (StatusTestNumber.HasValue ? " " + StatusTestNumber : "");
            }
        }

        [Display(Name = "Результат")]
        public StatusState StatusState
        {
            get
            {
                return (StatusState)(StatusCode < -1000 ? StatusCode / 1000 - 1: StatusCode);
            }
        }

        public int? StatusTestNumber
        {
            get
            {
                if (StatusCode < -1000)
                    return -StatusCode % 1000;
                return null;
            }
        }
    }
}