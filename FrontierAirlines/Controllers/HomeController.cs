using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontierAirlines.Models;
using FrontierAirlines.Helpers;
using Newtonsoft.Json;

namespace FrontierAirlines.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            FrontierViewModel model = new FrontierViewModel();
            model.CurrentAccounts = new List<Accounts>();
            model.InactiveAccounts = new List<Accounts>();
            model.PastDueAccounts = new List<Accounts>();
            try
            {
                List<Accounts> accountList = new List<Accounts>();
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://frontiercodingtests.azurewebsites.net/api/accounts/getall"))
                    {
                        string frontierResponse = await response.Content.ReadAsStringAsync();
                        accountList = JsonConvert.DeserializeObject<List<Accounts>>(frontierResponse);
                    }
                }


                model.CurrentAccounts = accountList.Where(a => a.AccountStatusId == (int)Enums.AccountStatuses.Active).ToList();
                model.InactiveAccounts = accountList.Where(i => i.AccountStatusId == (int)Enums.AccountStatuses.Inactive).ToList();
                model.PastDueAccounts = accountList.Where(p => p.AccountStatusId == (int)Enums.AccountStatuses.Overdue).ToList();

            }
            catch (Exception ex)
            {
                //todo  Logging or throwing exceptions
            }

            return View(model);
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
