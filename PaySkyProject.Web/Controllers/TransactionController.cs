using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using paysky.Model;
using PaySkyProject.Security;

namespace PaySkyProject.Web.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create(TransactionViewModel transaction)
        {
            var obj = new JavaScriptSerializer().Serialize(transaction);

            var data = Security.Security.Encrypt(obj);

            var gatewayoptect = new
            {
                Value = data
            };
            var responseResult = "";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(gatewayoptect), Encoding.UTF8, "application/json");
                    //Post http callas.
                    HttpResponseMessage response = client.PostAsync("http://localhost:9000/Gateway.svc/ProcessTransaction", content).Result;
                    //nesekmes atveju error..
                    response.EnsureSuccessStatusCode();
                    //responsas to string
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    responseResult = responseBody;

                }
                catch (HttpRequestException e)
                {
                    
                }

            }

            var newtransaction = JsonConvert.DeserializeObject<Transaction>(Security.Security.Decrypt(responseResult));

            var message = newtransaction.Message;
            return View(message);
        }
    }
}