using DataLayer.Repository.Base;
namespace DataLayer.Repository
{
    public interface IMyTestObjectRepository:IMyAppBaseRepository
    {
        string GetHelloWorldFromDatabase();
    }
    public class MyTestObjectRepository : MyAppBaseRepository, IMyTestObjectRepository
    {
        public string GetHelloWorldFromDatabase()
        {
            //TO BE USED WHEN ENTITY FRAMEWORK table objects are available in MODELS
            //using (var context = GetMyAppDataContext)
            //{
            //    return context.MyTable.FirstOrDefault(i=>i.Name=='ABC').Select(n=>n.MyName);
            //}
            return "Hello World from DB!";
        }
    }
}
