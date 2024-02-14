﻿using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;

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
            throw new NotImplementedException();
        }

        public Session GetSessionById(int id)
        {
            throw new NotImplementedException();
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
