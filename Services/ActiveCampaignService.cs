using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ActiveCampaign.Net.Models;

namespace ActiveCampaign.Net.Services
{
    public abstract class ActiveCampaignService
    {
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiPassword { get; set; }

        protected ActiveCampaignService(string apiKey, string apiUrl, string apiPassword = null)
        {
            if (string.IsNullOrEmpty(apiUrl))
                throw new ArgumentException(Resources.ActiveCampaign.Invalid_API_Url, nameof(apiUrl));

            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException(Resources.ActiveCampaign.Invalid_API_key, nameof(apiKey));

            ApiKey = apiKey;
            ApiUrl = CreateBaseUrl(apiUrl) + "&api_key=" + apiKey;
            ApiPassword = apiPassword;
        }

        private string CreateBaseUrl(string apiUrl)
        {
            string cleanedUrl = Regex.IsMatch(apiUrl, "/$") ? apiUrl.Substring(0, apiUrl.Length - 1) : apiUrl;

            if (Regex.IsMatch(apiUrl, "https://www.activecampaign.com"))
                return cleanedUrl + "/api.php?api_output=json";

            return cleanedUrl + "/admin/api.php?api_output=json";
        }
        private string CreateBaseUrlV3(string accountName)
        {
            return "https://" + accountName + ".api-us1.com/api/3/";

        }

        /// <summary>
        /// Send Request method. 
        /// </summary>
        /// <param name="method">Active Campaign method name</param>
        /// <param name="getParameters">Optional. Dictionary with GET parameters</param>
        /// <param name="postParameters">Optional. Dictionary with POST parameters</param>
        /// <returns>JSON response as string from Active Campaign API</returns>
        public string SendRequestV3(string method, int? id, Dictionary<string, string> getParameters = null)
        {
            if (string.IsNullOrEmpty(method))
                throw new ArgumentException("A valid ActiveCampaign API method was not specified", nameof(method));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(ApiUrl);
            urlBuilder.Append(method + "/");

            //If request is in  format https://artshub.api-us1.com/api/3/campaigns/28
            if (id.HasValue) urlBuilder.Append(id.Value);

            //api_output JSON
            getParameters.Add("?api_output", "json");

            if (getParameters != null)
            {
                foreach (var parameter in getParameters)
                {
                    urlBuilder.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(parameter.Key), HttpUtility.UrlEncode(parameter.Value));
                }
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = (HttpWebRequest)WebRequest.Create(urlBuilder.ToString());

            //ArtsHub.BLL.Emailing.Emailing.EmailDebugging("ActiveCampaignService.SendRequestV3() > REQUEST : " + method + " at " + DateTime.Now.ToString("dd-MM-yyy HH:mm"), "Method : " + method + "<br>HTTP METHOD : " + request.Method + "<br>CONTENT TYPE : " + request.ContentType + "<br>RQUEST URI : " + urlBuilder.ToString());

            string jsonResponse;


            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                using (var readStream = new StreamReader(responseStream, Encoding.UTF8))
                {
                    jsonResponse = readStream.ReadToEnd();
                }
                //ArtsHub.BLL.Emailing.Emailing.EmailDebugging("ActiveCampaignService.SendRequest() > RESPONSE :  " + method + " at " + DateTime.Now.ToString("dd-MM-yyy HH:mm"), "response.ContentType : " + response.ContentType + "<br>response.StatusCode : " + response.StatusCode + "<br>  response.ContentLength : " + response.ContentLength + "<br>response.ResponseUri : " + response.ResponseUri + "<br> response.StatusDescription : " + response.StatusDescription + "<br> JSON : <br>" + jsonResponse);
            }

            return jsonResponse;
        }
        /// <summary>
        /// Check if response is successfull
        /// </summary>
        /// <param name="response">Result type</param>
        /// <returns>bool</returns>
        /// <summary>
        /// Send Request method. 
        /// </summary>
        /// <param name="method">Active Campaign method name</param>
        /// <param name="getParameters">Optional. Dictionary with GET parameters</param>
        /// <param name="postParameters">Optional. Dictionary with POST parameters</param>
        /// <returns>JSON response as string from Active Campaign API</returns>
        public string SendRequest(string method, Dictionary<string, string> getParameters, Dictionary<string, string> postParameters = null)
        {
            if (string.IsNullOrEmpty(method))
                throw new ArgumentException("A valid ActiveCampaign API method was not specified", nameof(method));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(ApiUrl);
            urlBuilder.Append("&api_action=").Append(method);


            //api_output JSON
            getParameters.Add("api_output", "json");

            //ArtsHub.BLL.Emailing.Emailing.EmailDebugging("ActiveCampaignService.SendRequest() > REQUEST BEFORE GET: " + method + " at " + DateTime.Now.ToString("dd-MM-yyy HH:mm"), "Method : " + method + "URL : " + urlBuilder.ToString());

            if (getParameters != null)
            {
                foreach (var parameter in getParameters)
                {
                    if (!string.IsNullOrEmpty(parameter.Key) && parameter.Value != null)
                    {
                        urlBuilder.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(parameter.Key), HttpUtility.UrlEncode(parameter.Value));
                    }
                }
            }

            //ArtsHub.BLL.Emailing.Emailing.EmailDebugging("ActiveCampaignService.SendRequest() > REQUEST BEFORE POST: " + method + " at " + DateTime.Now.ToString("dd-MM-yyy HH:mm"), "Method : " + method + "<br>HTTP METHOD : ");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = (HttpWebRequest)WebRequest.Create(urlBuilder.ToString());

            string postData = string.Empty;

            if (postParameters != null)
            {
                var requestData = new StringBuilder();

                foreach (var postParameter in postParameters)
                {
                    if (postParameter.Value != null)
                    {
                        requestData.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(postParameter.Key), HttpUtility.UrlEncode(postParameter.Value));
                    }
                }

                var postString = postData = requestData.ToString().Substring(1);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postString.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(Encoding.UTF8.GetBytes(postString), 0, postString.Length);
                }

            }

            //ArtsHub.BLL.Emailing.Emailing.EmailDebugging("ActiveCampaignService.SendRequest() > REQUEST AFTER POST: " + method + " at " + DateTime.Now.ToString("dd-MM-yyy HH:mm"), "Method : " + method + "<br>HTTP METHOD : " + request.Method + "<br>CONTENT TYPE : " + request.ContentType + "<br>RQUEST URI : " + urlBuilder.ToString() + "<br>" + postData);

            string jsonResponse;


            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                using (var readStream = new StreamReader(responseStream, Encoding.UTF8))
                {
                    jsonResponse = readStream.ReadToEnd();
                }
                //ArtsHub.BLL.Emailing.Emailing.EmailDebugging("ActiveCampaignService.SendRequest() > RESPONSE :  " + method + " at " + DateTime.Now.ToString("dd-MM-yyy HH:mm"), "response.ContentType : " + response.ContentType + "<br>response.StatusCode : " + response.StatusCode + "<br>  response.ContentLength : " + response.ContentLength + "<br>response.ResponseUri : " + response.ResponseUri + "<br> response.StatusDescription : " + response.StatusDescription + "<br> JSON : <br>" + jsonResponse);
            }

            return jsonResponse;
        }
        /// <summary>
        /// Check if response is successfull
        /// </summary>
        /// <param name="response">Result type</param>
        /// <returns>bool</returns>
        public bool IsRequestSuccessfull(Result response)
        {
            if (response.ResultCode == 1)
            {
                return true;
            }

            return false;
        }
    }
}