namespace AcuSharp.Integration
{
    /// <summary>
    /// A lightweight REST client wrapper around RestSharp for simplified and fluent HTTP requests.
    /// <para>
    /// Designed for use in Acumatica customizations and integrations, this utility enables easy execution of REST calls 
    /// with support for headers, parameters, and JSON bodies.
    /// </para>
    /// <para>
    /// Usage example: <b>ACSPRestSharp.Create("https://api.example.com").ExecuteRequest(...)</b>
    /// </para>
    /// </summary>
    public class ACSPRestSharp
    {
        #region Fields
        private readonly RestClient _client;
        /// <summary>
        /// The underlying RestClient instance used for making HTTP requests.
        /// </summary>
        public RestClient RestClient => _client;
        #endregion

        #region Constructor

        private ACSPRestSharp(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));

            _client = new RestClient(baseUrl);
        }

        #endregion

        #region Factory
        /// <summary>
        /// Creates a new instance of <see cref="ACSPRestSharp"/> with the specified base URL.
        /// </summary>
        /// <param name="baseUrl"> The base URL for the REST client.</param>
        /// <returns></returns>
        public static ACSPRestSharp Create(string baseUrl) => new(baseUrl);

        #endregion

        #region Execution

        /// <summary>
        /// Executes a REST request against the configured base URL.
        /// </summary>
        /// <param name="method">HTTP method (GET, POST, etc).</param>
        /// <param name="resource">Endpoint path (e.g., "/items").</param>
        /// <param name="body">Optional body to send as JSON.</param>
        /// <param name="headers">Optional headers to include.</param>
        /// <param name="parameters">Optional parameters (query or others).</param>
        /// <returns>The <see cref="RestResponse"/> returned by RestSharp.</returns>
        public RestResponse ExecuteRequest(
            Method method = Method.Get,
            string resource = "",
            object body = null,
            Dictionary<string, string> headers = null,
            IEnumerable<RestSharp.Parameter> parameters = null)
        {
            var request = new RestRequest(resource, method);

            if (headers != null)
                request.AddHeaders(headers);

            if (parameters != null)
                request.AddOrUpdateParameters(parameters);

            if (body != null)
                request.AddJsonBody(body);

            return _client.Execute(request);
        }

        #endregion
    }

}
