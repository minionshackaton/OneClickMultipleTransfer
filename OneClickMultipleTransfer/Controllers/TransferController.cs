using OneClickMultipleTransfer.Business;
using OneClickMultipleTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneClickMultipleTransfer.Controllers
{
    public class TransferController : Controller
    {
        // GET: Transfer
        [HttpGet]
        public ActionResult InitiateTransfer()
        {

           // PayeesAPI payeeAPI = new PayeesAPI();

            //var payeeList = payeeAPI.CallBeneficiariesAPI();

            TransferViewModel transferDetails = new TransferViewModel();
            transferDetails.PayeeList = new List<Payee> { new Payee { PayeeName="Payee One",AccountNumber="1234", },
            new Payee { PayeeName="Payee Two",AccountNumber="12345" },
            new Payee { PayeeName="Payee Three",AccountNumber="123456" }};
            return View(transferDetails);
        }

        [HttpPost]
        public ActionResult InitiateTransfer(TransferViewModel tranferDetailsViewModel)
        {

            List<TransferDetails> transferDetails = new List<TransferDetails>();

            transferDetails.AddRange(tranferDetailsViewModel.TransferDetailsList);

            TempData.Add("transferDetails",transferDetails);

            return RedirectToAction("ConfirmTransfer", "Transfer", transferDetails);
        }

        [HttpGet]
        public ActionResult ConfirmTransfer(List<TransferDetails> transferDetails)
        {            
            var data = (Object)TempData["transferDetails"];
            TempData.Keep("transferDetails");
            IEnumerable <TransferDetails> listTransfer = (List<TransferDetails>)data;
            return View(listTransfer);
        }

        [HttpPost]
        public ActionResult ConfirmTransfer(string confirm)
        {
            return RedirectToAction("TransferCompleted", "Transfer");
        }

        [HttpGet]
        public ActionResult TransferCompleted()
        {
            var data = (Object)TempData["transferDetails"];
            TempData.Keep("transferDetails");
            List<TransferDetails> listTransfer = (List<TransferDetails>)data;
            listTransfer[0].TransferStatus = "Success";
            listTransfer[1].TransferStatus = "Falied";

            IEnumerable<TransferDetails> finalList = listTransfer;
            return View(finalList);
        }
    }
}