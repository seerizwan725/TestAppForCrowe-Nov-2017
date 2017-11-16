using DataLayer.Models;

namespace DataLayer.Repository.Base
{
    public interface IMyAppBaseRepository : IBaseRepository
    {
    }
    public abstract class MyAppBaseRepository:BaseRepository,IMyAppBaseRepository
    {
        protected MyAppContext GetMyAppDataContext()
        {

            return new MyAppContext();

        }
    }
}
