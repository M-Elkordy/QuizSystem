using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuba_Staterkit.RepoServices
{
    public class SessionRepoService : IClassSession
    {
        public Context Context { get;}
        public SessionRepoService( Context context) 
        {
            Context = context;
        }
  
        public List<Session> GetAll()
        {
            return(Context.Sessions.Include(q=>q.quiz).ToList());
        }
        public Session GetSessionById(int id)
        {
            throw new NotImplementedException();
        }
        public bool SessionExists(string name)
        {
            Session? session = GetSessionByName(name);
            return session != null ? true : false;
        }
        public Session? GetSessionByName(string name)
        {
            Session? session = Context.Sessions.FirstOrDefault(s => s.Name == name);
            return session;
        }
        public void InsertSession(Session session)
        {
            Context.Sessions.Add(session);
            Context.SaveChanges();
        }
        public void UpdateSession(int id, Session session)
        {
        }
        public void DeleteSession(int id)
        {
        }
    }
}
