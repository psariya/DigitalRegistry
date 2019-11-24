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
            
            string SocialMedia_API_PATH = BASE_URL + "v1/social_media.json";
            
            All_Social_Media socialMedia = null;

            // Connect to the API and retrieve information
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
                /*try
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.MissingMemberHandling = MissingMemberHandling.Error;*/

                socialMedia = JsonConvert.DeserializeObject<All_Social_Media>(socialMediaList);//, settings);
                /*}
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.GetType().Name + ": " + ex.Message);
                }*/

            }

            return socialMedia;
        }
               
        public IActionResult Index()
        {
            //Set ViewBag variable first
            //ViewBag.dbSuccessComp = 0;
            //All_Social_Media sMedia = GetSocialMedia();

            return View();// sMedia.results);
        }

        public IActionResult SocialMedia()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            All_Social_Media sMedia = GetSocialMedia();

            return View(sMedia.Results);
        }

        public IActionResult PopulateSocialMedia()
        {

            All_Social_Media sMedia = GetSocialMedia();
                        
                    foreach (Social_Media s in sMedia.Results)
                    {
                        if (dbContext.Social_Media.Where(c => c.Id.Equals(s.Id)).Count() == 0)
                        {
                            foreach (Agencies a in s.agencies)
                            {
                            //    if (dbContext.Agencies.Where(d => d.id.Equals(a.id)).Count() == 0)
                            //    {
                                    dbContext.Agencies.Add(a);
                            //    }
                            }
                            foreach (Tags t in s.tags)
                            {
                            //    if (dbContext.Tags.Where(b => b.id.Equals(t.id)).Count() == 0)
                            //    {
                                    dbContext.Tags.Add(t);
                            //    }
                            }
                            dbContext.Social_Media.Add(s);
                        }
                    }
            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("SocialMedia", sMedia.Results);
        }

        public IActionResult AboutUs()
        {
            return View("AboutUs");
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
