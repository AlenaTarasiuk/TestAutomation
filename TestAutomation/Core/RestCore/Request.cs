using RestSharp;

namespace TestAutomation.Core.RestCore
{
    public class Request
    {
        private RestRequest request;
        private string _body;

        public Request()
        {
            request = RequestFactory.Create<RestRequest>();
            request.Parameters.Clear();
        }

        public Request WithMethod(Method method)
        {
            request.Method = method;
            return this;
        }

        public Request WithBody(string body, DataFormat dataFormat = DataFormat.Json)
        {
            var contentType = request.JsonSerializer.ContentType;
            _body = body;
            request.AddParameter(contentType, body, ParameterType.RequestBody);
            return this;
        }

        public Request WithBody(object obj)
        {
            request.AddJsonBody(obj);
            return this;
        }

        public Request WithQueryParameter(string name, string value)
        {
            request.AddQueryParameter(name, value);
            return this;
        }

        public Request WithParameter(string name, object value)
        {
            request.AddParameter(name, value);
            return this;
        }

        public Request WithParameter(string name, object value, ParameterType type)
        {
            request.AddParameter(name, value, type);
            return this;
        }

        public Request WithHeader(string name, string value)
        {
            request.AddHeader(name, value);
            return this;
        }

        public Request WithReqFormat(DataFormat dataFormat)
        {
            request.RequestFormat = dataFormat;
            return this;
        }

        public Request WithAccessToken(string token)
        {
            request.AddHeader("Authorization", "Bearer " + token);
            return this;
        }

        public RestRequest Build()
        {
            return request;
        }
    }
}
