using DTDOrganizer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DTDOrganizer.Controllers
{
    public class LibraryController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Library
        public ActionResult Index()
        {
            var model = new LibraryViewModel
            {
                books = db.BooksModels.ToList(),
                courses = db.CoursesModels.ToList(),
                documents = db.DocumentsModels.ToList()
            };
            
            return View(model);
        }
        public ActionResult BookDesc()
        {
            return View();
        }

        // GET: Library/AddBook
        public ActionResult AddBook()
        {
            return View();
        }

        // POST: Library/AddBook
        [HttpPost]
        public ActionResult AddBook(FormCollection collection)
        {
            
            try
            {
                // TODO: Add db insert logic here
                //9780596007126 - Head First Design Patterns
                string isbn = collection["isbn"];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/books/v1/volumes?q=isbn:" + isbn +"&key=AIzaSyARYJrBPVJ9B77JveSDkwPI5IvWUGVHe1M");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string book = new StreamReader(response.GetResponseStream()).ReadToEnd();
                JObject jsonBook = JObject.Parse(book);
                JArray authorsArray = (JArray)jsonBook["items"][0]["volumeInfo"]["authors"];
                BooksModel addBook = new BooksModel()
                {
                    isbn = isbn,
                    title = (string)jsonBook["items"][0]["volumeInfo"]["title"],
                    authors = authorsArray.Select(a => (string)a).ToList<string>(),
                    pages = (int)jsonBook["items"][0]["volumeInfo"]["pageCount"],
                    publisher = (string)jsonBook["items"][0]["volumeInfo"]["publisher"],
                    publishedDate = (string)jsonBook["items"][0]["volumeInfo"]["publishedDate"],
                    description = (string)jsonBook["items"][0]["volumeInfo"]["description"],
                    rating = (float)jsonBook["items"][0]["volumeInfo"]["averageRating"],
                    imagePath = (string)jsonBook["items"][0]["volumeInfo"]["imageLinks"]["thumbnail"]
                };

                db.BooksModels.Add(addBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Library/Create
        public ActionResult AddCourse()
        {
            return View();
        }

        // POST: Library/Create
        [HttpPost]
        public ActionResult AddCourse(FormCollection collection)
        {

            try
            {
                // TODO: Add db insert logic here
                CoursesModel newCourse = new CoursesModel
                {
                    name = collection["name"],
                    link = collection["link"]
                };
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Library/Create
        public ActionResult AddDocument()
        {
            return View();
        }

        // POST: Library/Create
        [HttpPost]
        public ActionResult AddDocument(DocumentUploadModel document)
        {

            try
            {
                // TODO: Add db insert logic here
                DocumentsModel addDocument = new DocumentsModel
                {
                    name = document.fileName
                };
                if (document.File.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(document.File.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/Documents"), _FileName);
                    document.File.SaveAs(_path);
                    addDocument.path = _path;
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

    }
}