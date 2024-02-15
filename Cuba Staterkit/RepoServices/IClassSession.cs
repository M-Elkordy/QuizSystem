using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface IClassSession
    {
        public List<Session> GetAll();
        public Session GetSessionById(int id);
        public Session GetSessionByName(string name);
        public bool SessionExists(string name);
        public void InsertSession(Session session);
        public void UpdateSession(int id, Session session);
        public void DeleteSession(int id);

    }
}
