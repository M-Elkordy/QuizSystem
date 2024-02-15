namespace Cuba_Staterkit.Models
{
    public class ClassSessionVm
    {
        public string QuizName { get; set; }
        public string HomeworkName { get; set; }
        public string SessionName { get; set;}
        public Quiz Quiz { get; set;}
        public HomeWork HomeWork { get; set;}
        public Session Session { get; set;}
    }
}
