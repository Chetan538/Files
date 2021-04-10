using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Application.Models;

namespace Application.Controllers
{
    public class OperationsController : Controller
    {
        // GET: Operations
        public ActionResult Index()
        {
            IEnumerable<stuff> stuffobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri(" http://localhost:65460/api/Inventory");
            var consumeapi = hc.GetAsync("Inventory");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<stuff>>();
                displaydata.Wait();
                stuffobj = displaydata.Result;


            }

            return View(stuffobj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(stuff insertstuff)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:65460/api/Inventory");
            var insertrecord = hc.PostAsJsonAsync<stuff>("Inventory", insertstuff);
            insertrecord.Wait();
            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }





        public ActionResult Details(int id)
        {
            stuff stuffobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:65460/api/");
            var consumeapi = hc.GetAsync("Inventory?id=" + id.ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<stuff>();
                displaydata.Wait();
                stuffobj = displaydata.Result;

            }

            return View(stuffobj);

        }
        public ActionResult Edit(int id)
        {
            stuff stuffobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:65460/api/Inventory");
            var consumeapi = hc.GetAsync("Inventory?id=" + id.ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<stuff>();
                displaydata.Wait();
                stuffobj = displaydata.Result;

            }

            return View(stuffobj);


        }

        [HttpPost]
        public ActionResult Edit(stuff st)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:65460/api/Inventory");
            var insertrecord = hc.PutAsJsonAsync<stuff>("Inventory", st);
            insertrecord.Wait();
            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.message = "not updated";
            }
            return View(st);

        }

        public ActionResult Delete(int id)
        {

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:65460/api/Inventory");
            var delrecord = hc.DeleteAsync("Inventory/" + id.ToString());
            delrecord.Wait();
            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Index");
        }

    }
}