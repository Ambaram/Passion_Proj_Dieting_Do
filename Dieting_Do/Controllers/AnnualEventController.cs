using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Dieting_Do.Models;
using System.Net.Http;

namespace Dieting_Do.Controllers
{
    public class AnnualEventController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static AnnualEventController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                UseCookies = false
            };

            client = new HttpClient(handler);
            client.BaseAddress = new  Uri("https://localhost:44324/api/");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// 
        /// </example>
        public ActionResult ListEvents()
        {
            string url = "AnnualEventData/ListEvents";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<AnnualEvent> annualEvents = response.Content.ReadAsAsync<IEnumerable<AnnualEvent>>().Result; 
            return View(annualEvents);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <example>
        /// 
        /// </example>
        public ActionResult FindEvent(int id)
        {
            string url = "AnnualEventData/FindEvent" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            AnnualEventDto selectedevent = response.Content.ReadAsAsync<AnnualEventDto>().Result;
            return View(selectedevent);
        }

        public ActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// 
        /// </example>
        [HttpGet]
        public ActionResult NewEvent()
        {
            string url = "ShelterData/ListShelter";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<ShelterDto> shelterist = response.Content.ReadAsAsync<IEnumerable<ShelterDto>>().Result;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        ///<param name="annualEvent"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <example>
        /// 
        /// </example>
        [HttpPost]
        public ActionResult AddEvent(AnnualEvent annualEvent)
        {
            string url = "AnnualEventData/AddEvent";
            string jsonpayload = jss.Serialize(annualEvent);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListEvents");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <example>
        /// GET : AnnualEvent/EditEvent
        /// </example>
        public ActionResult EditEvent(int id)
        {
            string url = "AnnualEventData/FindEvent" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            AnnualEventDto selectedEvent = response.Content.ReadAsAsync<AnnualEventDto>().Result;
            return View(selectedEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="annualEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateEvent(int id, AnnualEvent annualEvent)
        {
            string url = "AnnualEventData/UpdateEvent" + id;
            string jsonpayload =jss.Serialize(annualEvent);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListEvents");
            }
            else
            {
                return RedirectToAction("Error");
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <example>
        /// 
        /// </example>
        [HttpGet]
        [Authorize]
        public ActionResult DeleteConfirm(int id)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="annualEvent"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <example>
        /// 
        /// </example>
        [HttpPost]
        [Authorize]
        public ActionResult DeleteEvent(int id, AnnualEvent annualEvent)
        {
            string url = "AnnualEventData/DeleteEvent" + id;

            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListEvents");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
