using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChecker
{
    /// <summary>
    /// Wrapper class for the API family of:
    /// https://rapidapi.com/apidock-apidock-default/api/pricecharting-api
    /// </summary>
    public class VGCPriceCheckRapidAPI : RapidAPIBase
    {
        /// <summary>
        /// The full URL to be called
        /// </summary>
        public string SearchAPIURL { get;
            set
            {
                //.NET6+
                ArgumentNullException.ThrowIfNull(value);
                if (value == string.Empty) { throw new ArgumentNullException("SearchAPIURL"); }
                field = value;
            }
        } = "";

        public VGCPriceCheckRapidAPI(
            string pAPIEndpointURL,
            string pHostURL,
            string pAPIKey) : base(pAPIEndpointURL, pHostURL, pAPIKey)
        {
            //Exposure of base constructor
        }

        protected override void SetRequestBody(RestRequest pRestReq)
        { 
            //Set the search URL in body
            ArgumentNullException.ThrowIfNull(pRestReq);

            var jsonBody = new
            {
                url = SearchAPIURL
            };

            // Add the object, RestSharp serializes it as JSON
            pRestReq.AddJsonBody(jsonBody);
        }

    }
}
