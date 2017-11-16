using System.Web.Mvc;
using CommandLayer.Shared;
using System.Configuration;

namespace CrowSampleApplication.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            InitializeCommandFactory();
        }

        protected CommandFactory CommandFactory
        {
            get { return System.Web.HttpContext.Current.Session["CommandFactory"] as CommandFactory; }
            set { System.Web.HttpContext.Current.Session["CommandFactory"] = value; }
        }

        protected void InitializeCommandFactory()
        {
            var sqlConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            CommandFactory = new CommandFactory(sqlConnStr, "MyApp");
        }
    }
}