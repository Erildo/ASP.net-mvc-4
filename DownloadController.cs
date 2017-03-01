using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unilast.Models;

namespace Uni.Controllers
{
    public class DownloadController : Controller
    {
        //
        // GET: /Download/

        public ActionResult Index()
        {
            return View();
        }
        public void ExportToCSV()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"klasaid\",\"emriklases\",\"vendodhja\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=klasa.csv");
            Response.ContentType = "application/octet-stream";

            udb db = new udb();

            var klasat = db.Keuni.ToList();

            foreach (var klasa in klasat)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
                    klasa.klasaid,
                    klasa.emriklases,
                    klasa.vendodhja
                    ));
            }
            Response.Write(sw.ToString());
            Response.End();

        }

    }
}