using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace TMSandbox.Lib.ServiceHelper;

public class TMSandboxHelper
{
    private static readonly Uri BaseUrl = new("https://api.tmsandbox.co.nz");

    public static object GetCategoriesDetails(int categoryId, bool catalogue)
    {
        var client = new HttpClient();
        var getCategoriesDetailsUrl = $@"{BaseUrl}/v1/Categories/{categoryId}/Details.json?catalogue={catalogue}";
        // client.BaseAddress = new Uri(BaseUrl);
        var response = client.GetAsync(getCategoriesDetailsUrl).Result;
        if (!response.IsSuccessStatusCode)
        {
            Assert.Inconclusive($"Unable to get expected response from the TMSandbox service. Code {response.StatusCode}. Details: {response.Content}");
        }

        return response.Content.ReadAsStringAsync().Result;
    }

    public static bool IsAlive()
    {
        var client = new HttpClient();
        //client.BaseAddress = new Uri(BaseUrl);
        var response = client.GetAsync(BaseUrl).Result;
        return response.StatusCode is HttpStatusCode.Forbidden;
    }
}
