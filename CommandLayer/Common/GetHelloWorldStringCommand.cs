using System;
using CommandLayer.Shared;
using DataLayer.Repository;

namespace CommandLayer.Common
{
    public class GetHelloWorldStringCommand : BaseCommand
    {
        public string Execute()
        {
            try
            {
                var myRepo = DBRepositoryFactory.Create<IMyTestObjectRepository>();
                //Call Repository function here to get data from DB
                var myreturnString = myRepo.GetHelloWorldFromDatabase();
                return myreturnString;
            }
            catch (Exception exc)
            {
                return "Error occured." + exc.Message;
            }
        }


    }
}
