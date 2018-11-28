using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonutAPI.Models;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

namespace DonutAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://grandcircusco.github.io/demo-apis/donuts.json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //get response stream
                StreamReader reader = new StreamReader(response.GetResponseStream());

                //read repsonse as a string
                string output = reader.ReadToEnd();//output to put into JSON in a sec
                //reader.Close(); do it below or up here

                //convert response to JSON
                JObject parser = JObject.Parse(output);//gives an array of objects

                reader.Close();
                response.Close();
                
                TempData.Add("donuts", parser["results"]);
                return View();
            }
            ViewBag.Error = "Something Went Wrong!";
            return View();
        }
        public ActionResult DonutDeets(string id)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://grandcircusco.github.io/demo-apis/donuts/"+id+".json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string output = reader.ReadToEnd();//output to put into JSON in a sec
                JObject parser = JObject.Parse(output);//gives an array of objects

                reader.Close();
                response.Close();

                ViewBag.ThisDonut = parser;
                return View();
            }
            ViewBag.Error = "Something Went Wrong!";
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
    }
}