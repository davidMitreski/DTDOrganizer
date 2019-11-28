using DTDOrganizer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTDOrganizer.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCalendarData()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\mitre\\source\\repos\\DTDOrganizer\\DTDOrganizer\\Content\\CalendarData\\CalendarEvents.json"))
            {
                string json = r.ReadToEnd();
                List<CalendarModel> items = JsonConvert.DeserializeObject<List<CalendarModel>>(json);

                return Json(items);
            }
            
        }
    }
}