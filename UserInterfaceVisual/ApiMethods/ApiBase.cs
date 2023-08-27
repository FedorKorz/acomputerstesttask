using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using UserInterfaceVisual.Resources;

namespace ACompsTestTask.APIMethods;

public class ApiBase
{
    public static async Task<HttpClient> InitializeHttpClient()
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(new X509Certificate2("C:/Users/user/Downloads/cert/manager.pfx",
            ExternalVarsStorage.Passwrod));

        var httpClient = new HttpClient(handler);
        httpClient.BaseAddress = new Uri("https://demo.u-system.tech");

        return httpClient;
    }
}