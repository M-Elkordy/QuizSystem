using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public class HomeWorkRepoService : IHomeWork
    {
        public Context Context { get; }
        public HomeWorkRepoService(Context context)
        {
            Context = context;
        }
        public List<HomeWork> GetAll()
        {
            throw new NotImplementedException();
        }

        public HomeWork GetHomeWorkById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertHomeWork(HomeWork homework)
        {
            
        }

        public void UpdateHomeWork(int id, HomeWork homework)
        {
            
        }

        public void DeleteHomeWork(int id)
        {
            
        }
    }
}
