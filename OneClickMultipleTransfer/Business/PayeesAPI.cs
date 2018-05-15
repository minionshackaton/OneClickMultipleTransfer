using Newtonsoft.Json.Linq;
using OneClickMultipleTransfer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace OneClickMultipleTransfer.Business
{
    public class PayeesAPI
    {
        public List<Payee> CallBeneficiariesAPI()
        {
            var webRequest = WebRequest.Create("https://ob-api.innovationwide.co.uk/api/accounts/94773361/beneficiaries") as HttpWebRequest;
            if (webRequest == null)
            {
                return null;
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            List<Payee> accountList = new List<Payee>();
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();

                    JObject AccountDataObject = Newtonsoft.Json.Linq.JObject.Parse(contributorsAsJson);

                    foreach (var item in AccountDataObject.SelectToken("Data[0]"))
                    {
                        accountList.Add(new Payee()
                        {
                            AccountNumber = FindValue(item, 0),
                            PayeeName = FindValue(item, 1)

                        });
                    }

                }
            }

            return accountList;
        }

        private static string FindValue(JToken item, int readIndex)
        {
            return ((JValue)item.First.ToObject<JContainer>().Children().AsJEnumerable().ToArray()[readIndex].AsJEnumerable().ToArray()[0].ToString()).Value.ToString();
        }
    }
}