using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface IQuiz
    {
        public List<Quiz> GetAll();
        public Quiz GetQuizById(Guid id);
        public void InsertQuiz(Quiz quiz);
        public void UpdateQuiz(int id, Quiz quiz);
        public void DeleteQuiz(int id);
        public bool QuizExist(Guid id);
    }
}
