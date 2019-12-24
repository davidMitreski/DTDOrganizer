using DTDOrganizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTDOrganizer.Controllers
{
    public class FoodController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Food
        public ActionResult Index()
        {
            FoodViewModel model = new FoodViewModel
            {
                restaurants = db.RestaurantModels.ToList(),
                dailyOrders = db.OrdersModels.ToList()
                                .Where(o => o.orderDate.Equals(DateTime.Now.Date.ToString("dd/MM/yyyy")))
                                .ToList()
            };
            return View(model);
        }

        public ActionResult PlaceOrder(string order, string restaurant)
        {
            //TODO: Implement db logic
            OrdersModel newOrder = new OrdersModel
            {
                order = order,
                restaurantName = restaurant,
                employee = "DEFAULT EMPLOYEE", //This should get value from the authenthicated employee
                orderDate = DateTime.Now.Date.ToString("dd/MM/yyyy")
            };

            db.OrdersModels.Add(newOrder);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction("Index");
        }

        public ActionResult AddRestaurant()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurant(RestaurantViewModel model)
        {
            try
            {
                RestaurantModel addRestaurant = new RestaurantModel
                {
                    name = model.name,
                    priceRange = model.priceRange
                };
                if (model.menuImage.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(model.menuImage.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/Images/Restaurants"), _FileName);
                    model.menuImage.SaveAs(_path);
                    addRestaurant.menuImage = _path;
                }

                db.RestaurantModels.Add(addRestaurant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var restaurant = db.RestaurantModels.ToList().Find(r => r.id == id);
                if(restaurant != null) db.RestaurantModels.Remove(restaurant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}