using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GoogleGenerativeAI;



public class GenerativeAIService
{
    private readonly string _apiKey;
    private readonly string _model;
    private readonly string _url = "https://generativelanguage.googleapis.com/v1beta";

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public GenerativeAIService(
        string apiKey,
        string model = "gemini-pro")
    {
        _apiKey = apiKey;
        _model = model;

        _url += $"/models/{_model}:generateContent?key={_apiKey}";

        _httpClient = new HttpClient();

        var contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = contractResolver,
            Formatting = Formatting.Indented
        };
    }

    public async Task<ResponseModel> GenerateContentAsync(string message)
    {
        using (var request = new HttpRequestMessage(HttpMethod.Post, _url))
        {
            var requestModel = new RequestModel(message);

            string jsonContent = JsonConvert.SerializeObject(requestModel, _jsonSerializerSettings);

            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseModel>(responseContent);
            }
            else
            {
                Console.WriteLine("Error: " + response.ReasonPhrase);
            }
        }

        return null;
    }
}