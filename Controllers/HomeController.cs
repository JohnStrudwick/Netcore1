using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Json testing";

            return View();
        }
		[HttpPost]
		public async Task<ActionResult> action(string num)
		{
			ViewData["Message"] = "Json button pressed";
			string jsonString = "";
			string jsonStringForClass = "";
			var numm = num;


			using (var client = new HttpClient())
			{
				var baseUri = "http://country.openregister.org/entry/" + numm + ".json";
				client.BaseAddress = new Uri(baseUri);
				
				client.DefaultRequestHeaders.Accept.Clear();
				var response = await client.GetAsync(baseUri);
				if (response.IsSuccessStatusCode)
				{
					var responseJson = await response.Content.ReadAsStringAsync();
					//do something with the response here. Typically use JSON.net to deserialise it and work with it
					jsonString = responseJson;
					jsonStringForClass = jsonString.Replace('-', '_');
				}

			}
			var objNewClass = JsonConvert.DeserializeObject<Country>(jsonStringForClass);
			string testString = (string)objNewClass.entry.official_name;

			ViewData["Message"] = jsonString;
			return View("About");
		}

		[HttpPost]
		public async Task<ActionResult> actionAll(string num)
		{
			ViewData["Message"] = "JsonAll button pressed";
			string jsonString = "";
			string jsonStringForClass = "";
			


			using (var client = new HttpClient())
			{
				var baseUri = "http://country.openregister.org/entries.json";
				client.BaseAddress = new Uri(baseUri);

				client.DefaultRequestHeaders.Accept.Clear();
				var response = await client.GetAsync(baseUri);
				if (response.IsSuccessStatusCode)
				{
					var responseJson = await response.Content.ReadAsStringAsync();
					//do something with the response here. Typically use JSON.net to deserialise it and work with it
					jsonString = responseJson;
					jsonStringForClass = jsonString.Replace('-', '_');
				}

			}
			JArray jObject = JArray.Parse(jsonString);
			
			var firstItem = jObject[0].ToString();
			jsonStringForClass = firstItem.Replace('-', '_');
			var firstItemSerialNumber = jObject[0]["serial-number"].ToString();
			var objNewClass = JsonConvert.DeserializeObject<Country>(jsonStringForClass);

			var items = jObject.Where(x => x["serial-number"].ToString() == "200").ToList();


			ViewData["Message"] = "JsonAll button pressed - - " + jsonString;
			return View("About");
		}

		public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
