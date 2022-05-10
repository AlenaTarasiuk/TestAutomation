using RestSharp;
using System.Net;

namespace TestAutomation.Core.RestCore
{
    public class CoreClient
    {
        public RestClient Client { get; set; }

        public CoreClient(string endpoint)
        {
            Client = new RestClient(endpoint);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public static CoreClient Instance(string endpoint) => new CoreClient(endpoint);

        public RestResponse<dynamic> ExecuteDynamic(Request request)
        {
            return Client.ExecuteDynamic(request.Build());
        }

        public IRestResponse Execute(Request request)
        {
            return Client.Execute(request.Build());
        }
    }
}