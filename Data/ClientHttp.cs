namespace AplicacionLibreriaCRUD.Data
{
    public class ClientHttp
    {
        public HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:7084")
            };

            return httpClient;
        }
    }
}
