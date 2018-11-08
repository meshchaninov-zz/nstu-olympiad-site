using System.ComponentModel.DataAnnotations;

namespace nstu_olympiad_site.ViewModels
{
    public class SubmitSolutionViewModel
    {
        [Required(ErrorMessage = "Нужно выбрать задачу!")]
        [Display(Name = "Задача")]
        public int ProblemId { get; set; }

        [Required(ErrorMessage = "Нужно выбрать компилятор!")]
        [Display(Name = "Компилятор")]
        public int CompilatorId { get; set; }

        [Required(ErrorMessage = "Нужно вставить код решения!", AllowEmptyStrings = false)]
        [Display(Name = "Код с решением")]
        [DataType(DataType.MultilineText)]
        public string CodeText { get; set; }    
    }
}