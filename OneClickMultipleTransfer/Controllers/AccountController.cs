using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OneClickMultipleTransfer.Models;
using OneClickMultipleTransfer.Business;
using System.Collections.Generic;

namespace OneClickMultipleTransfer.Controllers
{    
    public class AccountController : Controller
    {      
        public AccountController()
        {

        }

        [HttpGet]
        public ActionResult AccountBalance()
        {
            AccountBalanceAPI accountsAPI = new AccountBalanceAPI();

            var accountList = accountsAPI.CallAccountBalanceAPI();
            AccountViewModel viewModel = new AccountViewModel();
            viewModel.AccountList = accountList;
            return View("DisplayAccountBalance", viewModel);

        }

        [HttpPost]
        public ActionResult GotoTransferSection()
        {
            return RedirectToAction("InitiateTransfer","Transfer");
        }

       
    }


}