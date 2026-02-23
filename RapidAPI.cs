using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PriceChecker
{
    
    /// <summary>
    /// Wrapper for APIs hosted on Rapid API
    /// </summary>
    public abstract class RapidAPIBase
    {
        /// <summary>
        /// Client Endpoint URL
        /// </summary>
        protected string APIEndpointUrl { get; 
            set
            {
                //.NET6+
                ArgumentNullException.ThrowIfNull(value);
                if (value == string.Empty) { throw new ArgumentNullException("APIClientEndpointUrl"); }
                //TODO Next, we should validate that the URL provided is not malicious
                // See libs for Urlscan.io  or Google Safe Browse
                field = value;
            }
        }
        /// <summary>
        /// Hosting site URL
        /// </summary>
        protected string APIHostUrl { get; 
            set
            {
                //.NET6+
                ArgumentNullException.ThrowIfNull(value);
                if (value == string.Empty) { throw new ArgumentNullException("APIHostUrl"); }
                //TODO Next, we should validate that the URL provided is not malicious
                // See libs for Urlscan.io  or Google Safe Browse
                field = value;

            }
        } = "rapidapi.com";
        /// <summary>
        /// License Key for the API
        /// </summary>
        protected string APIKey { get;
            set
            {
                //.NET6+
                ArgumentNullException.ThrowIfNull(value);
                if (value == string.Empty) { throw new ArgumentNullException("APIKey"); }
                field = value;
            }
        }
        public int MaxAvailableCalls { get; set; } = 9999999;
        public int UsedCalls { get; set; }
        public DateTime AvailableCallResetDate { get; set; }


        /// <summary>
        /// Designer note: choosing this over interface model for simplicity
        /// </summary>
        /// <param name="pAPIEndpointURL">Client Endpoint</param>
        /// <param name="pAPIURL">Hosting site URL</param>
        /// <param name="pAPIKey">License key (always expected for RapidAPI listed APIs)</param>
        internal RapidAPIBase(string pAPIEndpointURL, string pAPIURL, string pAPIKey) {
            //Mandatory vars
            APIEndpointUrl = pAPIEndpointURL;
            APIHostUrl = pAPIURL;
            APIKey = pAPIKey;
        }

        /// <summary>
        /// Define the common header info, with flexibility to expand
        /// </summary>
        /// <param name="pRestReq">Previously generated REST request</param>
        protected virtual void SetRequestHeader(RestRequest pRestReq) {
            ArgumentNullException.ThrowIfNull(pRestReq);
            pRestReq.AddHeader("x-rapidapi-key", APIKey);
            pRestReq.AddHeader("x-rapidapi-host", APIHostUrl);
            pRestReq.AddHeader("Content-Type", "application/json");
        }

        /// <summary>
        /// Define the payload for specific API; cannot do this at base level.
        /// </summary>
        /// <param name="pRestReq">Previously generated REST request</param>
        protected abstract void SetRequestBody(RestRequest pRestReq);

        /// <summary>
        /// Prepares a new Rest Request for a Rapid API call.
        /// </summary>
        /// <returns>RestRequest object</returns>
        private RestRequest ConstructJsonRequest()
        {
            var theRequest = new RestRequest();
            SetRequestHeader(theRequest);
            SetRequestBody(theRequest);       
            
            return theRequest;
        }

        /// <summary>
        /// Executes a POST with a generated request.
        /// </summary>
        /// <returns>RestResponse object</returns>
        public RestResponse ExecutePost()
        {
            RestResponse theResponse;
            RestClient theClient = new RestClient(APIEndpointUrl);
            RestRequest theRequest = ConstructJsonRequest();
            UsedCalls++;
            theResponse = theClient.ExecutePost(theRequest);  

            return theResponse;
        }

        /// <summary>
        /// Executes a POST Asynchronously with a generated request.
        /// </summary>
        [Obsolete("INACTIVE: Plan to rework this implem to produce async calls")]
        private async void ExecutePOSTAsync()
        {
            RestResponse theResponse;
            RestClient theClient = new RestClient(APIEndpointUrl);
            RestRequest theRequest = ConstructJsonRequest();
            UsedCalls++;
            theResponse = await theClient.ExecuteAsync(theRequest);
            //Now what?
        }
    }
}
