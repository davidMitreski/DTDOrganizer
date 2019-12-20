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
        private MyDBContext db = new MyDBContext();
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCalendarData()
        {
            var model = db.CalendarEventModels.ToList();
            return Json(model);

        }
        // GET: Calendar/AddEvent
        public ActionResult AddEvent()
        {
            return View();
        }

        // POST: Calendar/AddEvent
        [HttpPost]
        public ActionResult AddEvent(CalendarEventViewModel newEvent)
        {
            try
            {
                CalendarEventModel calendarEvent = new CalendarEventModel
                {
                    title = newEvent.title,
                    color = Enum.GetName(typeof(eventColor), newEvent.color),
                    description = newEvent.description,
                    start = newEvent.startDate.Date.ToString("yyyy-MM-dd") + "T" + newEvent.startTime + ":00",
                    allDay = newEvent.allDay
                };
                if (!calendarEvent.allDay) {
                    calendarEvent.end = newEvent.endDate + "T" + newEvent.endTime + ":00";
                }
                else {
                    calendarEvent.end = null;
                }

                db.CalendarEventModels.Add(calendarEvent);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteEvent(string id)
        {
            var calendarEvent = db.CalendarEventModels.ToList().FirstOrDefault(e => e.id == int.Parse(id));
            if (calendarEvent != null) {
                db.CalendarEventModels.Remove(calendarEvent);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return Json("success");
        }

        [HttpPost]
        public ActionResult EditEvent(CalendarEventModel newEvent)
        {
            var calendarEvent = db.CalendarEventModels.ToList().FirstOrDefault(e => e.id == newEvent.id);
            if (calendarEvent != null)
            {
                calendarEvent.allDay = newEvent.allDay;
                calendarEvent.start = newEvent.start;
                calendarEvent.end = newEvent.end;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return View();
        }


    }
}