using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DigitalRegistry.Models;
using DigitalRegistry.DataAccess;

using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace DigitalRegistry.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        string BASE_URL = "https://api.gsa.gov/technology/digital-registry/";
        string API_KEY = "UeBsvN5CGLCQ3RW4DMwqtcmnY1YdTWlNMd6VL69I";
        HttpClient httpClient;
        string socialMediaList;// = "";

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("x-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public All_Social_Media GetSocialMedia()
        {
            //string Blogs_API_PATH = BASE_URL + "/blogs?api_key=";
            string SocialMedia_API_PATH = BASE_URL + "v1/social_media.json";
            //string socialMediaList = "";
            All_Social_Media socialMedia = null;

            // Connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(SocialMedia_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(SocialMedia_API_PATH).GetAwaiter().GetResult();

            // Read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                socialMediaList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // Parse the Json strings as C# objects
            if (!socialMediaList.Equals(""))
            {
                socialMedia = JsonConvert.DeserializeObject<All_Social_Media>(socialMediaList);
                //TempData["All_Social_Media"] = socialMediaList;
            }

            return socialMedia;
        }
               
        public IActionResult Index()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            All_Social_Media sMedia = GetSocialMedia();

            //Save sMedia in TempData, so they do not have to be retrieved again
            TempData["All_Social_Media"] = JsonConvert.SerializeObject(sMedia);
            
            return View(sMedia.results);
        }

        public IActionResult SocialMedia()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            All_Social_Media sMedia = GetSocialMedia();

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["All_Social_Media"] = JsonConvert.SerializeObject(sMedia);

            return View(sMedia.results);
        }

        public IActionResult PopulateSocialMedia()
        {

            //All_Social_Media sMedia = JsonConvert.DeserializeObject<All_Social_Media>(socialMediaList);
            All_Social_Media sMedia = GetSocialMedia();
            dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT All_Social_Media ON");
            dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Social_Media ON");
            dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Agencies ON");
            dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tags ON");
            foreach (Social_Media s in sMedia.results)
            {
                if (dbContext.Social_Media.Where(c => c.id.Equals(s.id)).Count() == 0)
                {
                    dbContext.Social_Media.Add(s);
                    //dbContext.Agencies.Add(s.agencies);

                }
            }
            //Priyanka is stuck here. Not able to save changes to database. SQL Identity_Insert is OFF error
            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", sMedia.results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
