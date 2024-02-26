using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface IQuestion
    {
        public List<Question> GetAll();
        public Dictionary<string, List<Question>> GetQuestionsByQuizId(Guid quizId);
        public Question GetQuestionById(int id);
        public void InsertQuestion(Question question);
        public void UpdateQuestion(int id, Question question);
        public void DeleteQuestion(int id);
    }
}
