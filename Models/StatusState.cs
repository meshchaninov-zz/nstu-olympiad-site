using System.ComponentModel.DataAnnotations;
 
namespace nstu_olympiad_site.Models
{
    public enum StatusState
    {
        [Display(Name = "В очереди...", ShortName = "Waiting")]
        InQueue = 0,
        [Display(Name = "Проверяется", ShortName = "Testing")]
        Testing = 1,
        [Display(Name = "ОК", ShortName = "OK")]
        Accepted = 2,
        [Display(Name = "Ошибка компиляции", ShortName = "CE")]
        CompilationError = -1,
        [Display(Name = "Неправильный ответ", ShortName = "WA")]
        WrongAnswer = -2,
        [Display(Name = "Превышение ограничений по времени", ShortName = "TL")]
        TimeLimit = -3,
        [Display(Name = "Ошибка выполнения", ShortName = "RE")]
        RuntimeError = -4,
        [Display(Name = "Ошибка выполнения", ShortName = "RE")]
        PresentationError = -5,
        [Display(Name = "Превышение ограничений по времени", ShortName = "TL")]
        IdlenessLimit = -6,
        [Display(Name = "Превышение ограничений по памяти", ShortName = "ML")]
        MemoryLimit = -7
    }
}