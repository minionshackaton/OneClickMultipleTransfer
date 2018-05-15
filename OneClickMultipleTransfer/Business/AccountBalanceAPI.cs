using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using OneClickMultipleTransfer.Models;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace OneClickMultipleTransfer.Business
{
    public class AccountBalanceAPI
    {
        public void GetAccountDetails()
        {

        }       
        public List<Account> CallAccountBalanceAPI()
        {
            var webRequest = WebRequest.Create("https://ob-api.innovationwide.co.uk/api/accounts/94773361") as HttpWebRequest;
            if (webRequest == null)
            {
                return null;
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            List<Account> accountList =new List<Account>();
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();

                    JObject AccountDataObject = Newtonsoft.Json.Linq.JObject.Parse(contributorsAsJson);
                                                        
                    foreach (var item in AccountDataObject.SelectToken("Data[0]"))
                    {
                        accountList.Add(new Account()
                        {
                            AccountId = FindValue(item, 0),
                            Currency = "100,000",//FindValue(item,1),
                            Nickname = FindValue(item,2)
                        });
                    }

                }
            }

            return accountList;
        }

        private static string FindValue(JToken item,int readIndex)
        {
            return ((JValue)item.First.ToObject<JContainer>().Children().AsJEnumerable().ToArray()[readIndex].AsJEnumerable().ToArray()[0].ToString()).Value.ToString();
        }
    }
}