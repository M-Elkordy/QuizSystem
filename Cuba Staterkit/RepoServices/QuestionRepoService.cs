using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public class QuestionRepoService : IQuestion
    {
        public Context Context { get; }
        public QuestionRepoService(Context context)
        {
            Context = context;
        }
        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestion(int id, Question question)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
