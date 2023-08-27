using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceVisual.Models;

namespace ACompsTestTask.APIMethods;

public class ApiMethods : ApiBase
{
    private const string Limit = "100";
    private const string Offset = "0";

    public static async Task<Response> GetAllUnits()
    {
        var httpClient = await InitializeHttpClient();
        var response = await httpClient.GetAsync($"/api/v1/org-units?limit={Limit}&offset={Offset}");
        var jsonResponse = await response.Content.ReadAsStringAsync();

        return new Response(
            jsonResponse,
            response.IsSuccessStatusCode,
            response.GetType(),
            response.StatusCode.ToString());
    }

    public static async Task<Response> PostNewUnit()
    {
        var httpClient = await InitializeHttpClient();

        var requestBody = @"
                {
                    ""parent_id"": ""9e680af9-a14c-4944-bc70-e1086d73e07b"",
                    ""type"": ""organization"",
                    ""name"": ""Company Created From API Request""
                }";

        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await httpClient.PostAsync("org-units",
            new StringContent(requestBody, Encoding.UTF8, "application/json"));
        var jsonResponse = await response.Content.ReadAsStringAsync();

        Console.WriteLine(jsonResponse);
        
        return new Response(
            jsonResponse,
            response.IsSuccessStatusCode,
            response.GetType(),
            response.StatusCode.ToString());
    }
}