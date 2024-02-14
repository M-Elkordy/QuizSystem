namespace Cuba_Staterkit.Models
{
    public class QuestionViewModel
    {
        public string Body { get; set; }
        public string ImgUrl { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }
        public string QuizID { get; set; }
        public string VersionID { get; set; }
    }

}
