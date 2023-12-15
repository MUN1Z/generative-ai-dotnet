using GoogleGenerativeAI;

string apiKey = "YOUR_API_KEY";

var gen = new GenerativeAIService(apiKey);

while (true)
{
    var line = Console.ReadLine();

    if (!string.IsNullOrEmpty(line))
    {
        var response = await gen.GenerateContentAsync(line);
        Console.WriteLine($"\n{response.Candidates.FirstOrDefault().Content.Parts.FirstOrDefault().Text}\n");
    }
}