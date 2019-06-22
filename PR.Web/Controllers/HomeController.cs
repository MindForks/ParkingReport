using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using ParkingReport.Models;
using PR.Business.Services;

namespace ParkingReport.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;
        private string _userId { get { return User.Identity.GetUserId(); } }

        public HomeController(UserService UserService)
        {
            _userService = UserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        [HttpGet]
        public IActionResult VerificateNumber()
        {
            SendSms();
            return View();
        }

        private async void SendSms()
        {

            var user = _userService.GetItemAsync(_userId);
            string number = user.PhoneNumber;
            int code = Convert.ToInt32(number.Substring(number.Length - 4)) >> 2;
            var XML = "XML=<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                        "<SMS>\n" +
                        "<operations>\n" +
                        "<operation>SEND</operation>\n" +
                        "</operations>\n" +
                        "<authentification>\n" +
                        "<username>mshtyr@softserveinc.com</username>\n" +
                        "<password>test1234!</password>\n" +
                        "</authentification>\n" +
                        "<message>\n" +
                        "<sender>SMS</sender>\n" +
                        "<text>" + code + "</text>\n" +
                        "</message>\n" +
                        "<numbers>\n" +
                        "<number messageID=\"msg11\">" + number + "</number>\n" +
                        "</numbers>\n" +
                        "</SMS>\n";
            HttpWebRequest request = WebRequest.Create("http://api.atompark.com/members/sms/xml.php") as HttpWebRequest;
            request.Method = "Post";
            request.ContentType = "application/x-www-form-urlencoded";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(XML);
            request.ContentLength = data.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string s = reader.ReadToEnd();
                //Console.ReadKey();
            }

        }

        [HttpPost]
        public async Task<ViewResult> NumberAprove(int codeVerification)
        {
            var user = _userService.GetItemAsync(_userId);
            string number = user.PhoneNumber;
            int code = Convert.ToInt32(number.Substring(number.Length - 4)) >> 2;
            if (codeVerification == code)
            {
                user.IsNumberAproved = true;
                await _userService.UpdateAsync(user);

            }
                
            return View();
        }

        [HttpGet]
        public  bool IsNumberVerificate()
        {
            var user = _userService.GetItemAsync(_userId);

            return user.IsNumberAproved;
        }

        [HttpGet]
        public ViewResult NumberAprove()
        {
            
            return View();
        }
    }
}
