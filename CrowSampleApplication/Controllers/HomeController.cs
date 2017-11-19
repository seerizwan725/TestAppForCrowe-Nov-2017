using System;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using CommandLayer.Common;

namespace CrowSampleApplication.Controllers
{
    public class CroweService
    {
        private const string Uri = "http://crowetestapinov2017.azurewebsites.net/api/values";
        public async Task<string> GetAsync()
        {
            using (var httpClient = new HttpClient())
            {

                return await httpClient.GetStringAsync(Uri);
            }
        }
    }
    public class HomeController : BaseController
    {
        private readonly CroweService _service = new CroweService();
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> HelloWorld()
        {
            try
            {
                var whatKindOfDataSource = ConfigurationManager.AppSettings["MyDataSource"];
                switch (whatKindOfDataSource)
                {
                    case "local":
                        ViewBag.Message = "Hello World from local source!";
                        break;
                    case "api":
                        ViewBag.Message = await _service.GetAsync();
                        break;
                    default:
                        string myDbString;
                        //Get from DB
                        using (var myCommand = CommandFactory.Create<GetHelloWorldStringCommand>())
                        {
                            myDbString = myCommand.Execute();
                        }
                        ViewBag.Message = myDbString;
                        break;
                }
            }
            catch (Exception exc)
            {
                ViewBag.Message = exc.Message;
            }
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetData()
        {
            ViewBag.Message = "Hello World!";
            return View();
        }
    }
}
