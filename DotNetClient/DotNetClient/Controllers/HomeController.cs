using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using DotNetClient.CodeCoordinationService;


namespace DotNetClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Submit()
        {
            if (Request.Files.Count > 2)
            {
                var file1 = Request.Files[0];
                var file2 = Request.Files[1];
                var file3 = Request.Files[2];
                if (file1 != null && file3 != null && file2 != null)
                {
                    var filename = Path.GetFileName(file1.FileName);
                    file1.SaveAs("E:\\codefolder\\" + filename);
                    filename = Path.GetFileName(file2.FileName);
                    file2.SaveAs("E:\\codefolder\\" + filename);
                    filename = Path.GetFileName(file3.FileName);
                    file3.SaveAs("E:\\codefolder\\" + filename);
                }
                CodeCoordinationService.CoordinationClient cordi = new CoordinationClient();
                cordi.setcodep(file1.FileName);
                cordi.setcodes(file2.FileName);
                cordi.settest(file3.FileName);
                cordi.setcodepl(language.cpp);
                cordi.setcodesl(language.cpp);
                cordi.settestl(language.cpp);
                cordi.execute();
            }
            else
            {
                ViewBag.x = "hii";
            }
            return View("Index");
        }
    }
}