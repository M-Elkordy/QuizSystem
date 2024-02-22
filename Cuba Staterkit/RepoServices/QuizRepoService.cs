using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuba_Staterkit.RepoServices
{
    public class QuizRepoService : IQuiz
    {
        public Context Context { get; }
        public QuizRepoService(Context context)
        {
            Context = context;
        }
        public List<Quiz> GetAll()
        {
            return Context.Quizes.Include(q => q.Session).ToList();
        }

        public Quiz GetQuiznById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertQuiz(Quiz quiz)
        {
            Context.Quizes.Add(quiz);
            Context.SaveChanges();
        }

        public void UpdateQuiz(int id, Quiz quiz)
        {
            
        }

        public void DeleteQuiz(int id)
        {
            
        }
    }
}
