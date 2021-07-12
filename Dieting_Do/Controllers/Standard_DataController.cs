﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dieting_Do.Models;
using System.Net.Http;
using Dieting_Do.Models.ViewModels;
using System.Web.Script.Serialization;

namespace Dieting_Do.Controllers
{
    public class Standard_DataController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static Standard_DataController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                //cookies are manually set in RequestHeader
                UseCookies = false
            };

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44324/api/Standard_Data/");
        }

        /// <summary>
        /// Grabs the authentication cookie sent to this controller.
        /// For proper WebAPI authentication, you can send a post request with login credentials to the WebAPI and log the access token from the response. 
        /// The controller already knows this token, so we're just passing it up the chain.
        /// </summary>
        private void GetApplicationCookie()
        {
            string token = "";
            //HTTP client is set up to be reused, otherwise it will exhaust server resources.
            //This is a bit dangerous because a previously authenticated cookie could be cached for
            //a follow-up request from someone else. Reset cookies in HTTP client before grabbing a new one.
            client.DefaultRequestHeaders.Remove("Cookie");
            if (!User.Identity.IsAuthenticated) return;

            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get(".AspNet.ApplicationCookie");
            if (cookie != null) token = cookie.Value;

            //collect token as it is submitted to the controller
            //use it to pass along to the WebAPI
            if (token != "") client.DefaultRequestHeaders.Add("Cookie", ".AspNet.ApplicationCookie=" + token);

            return;
        }
        /// <summary>
        /// Communicate with standard_data data controller web api to retrieve list of standard food requirement data present in the datatbase
        /// </summary>
        /// <returns>List of standard data</returns>
        /// <example>
        /// GET : Standard_Data/ListStandards
        /// </example>
        [HttpGet]
        public ActionResult ListStandards()
        {
            string url = "StandardList";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<Standard_Data> standards = response.Content.ReadAsAsync<IEnumerable<Standard_Data>>().Result;

            return View(standards);
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult NewStandard()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddStandard(Standard_Data standard_Data)
        {
            string url = "AddStandard";
            string jsonpayload = jss.Serialize(standard_Data);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListStandrds");
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
        public ActionResult EditStandard(int id)
        {
            string url = "FindStandard" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            St_Dto selectedstandard = response.Content.ReadAsAsync<St_Dto>().Result;

            return View(selectedstandard);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateStandard(int id, Standard_Data standard_Data)
        {
            string url = "UpdateStandard" + id;
            string jsonpayload = jss.Serialize(standard_Data);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListStandards");
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
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult DeleteStandard(int id, Standard_Data standard_Data)
        {
            string url = "DeleteStandard" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url , content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListStandards");
            }

            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
