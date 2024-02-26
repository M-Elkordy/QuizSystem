using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            Context.Questions.Add(question);
            Context.SaveChanges();
        }
        public void InsertQuestions(List<Question> questions)
        {
            foreach (Question question in questions)
            {
                Context.Questions.Add(question);
                Context.SaveChanges();
            }
        }

        public void UpdateQuestion(int id, Question question)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Question>> GetQuestionsByQuizId(Guid quizId)
        {
            IQueryable<Question> result = Context.Questions.Where(q => q.QuizID == quizId).OrderBy(q => q.VersionID);
            Dictionary<string, List<Question>> versionIdGroups = result.GroupBy(q => q.VersionID)
                                                                      .ToDictionary(g => g.Key, g => g.ToList());

            return versionIdGroups;
        }
    }
}
