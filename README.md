# Google AI DotNet SDK

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Discord](https://img.shields.io/discord/507641974421979145?label=Discord)](https://discord.gg/cjxa6bjD)
[![GitHub stars](https://img.shields.io/github/stars/mun1z/generative-ai-dotne?label=stargazers&logoColor=yellow&style=social)](https://github.com/mun1z/generative-ai-dotnet/stargazers)

For example, with just a few lines of code, you can access Gemini's multimodal capabilities to generate text from text input:
```C#
using GoogleGenerativeAI;

var gen = new GenerativeAIService("YOUR_API_KEY");
var response = await gen.GenerateContentAsync("");
var firstPart =  response.Candidates.FirstOrDefault().Content.Parts.FirstOrDefault();

Console.WriteLine(firstPart.Text);
```

## Try out the sample Dotnet console app

This repository contains a sample app demonstrating how the SDK can access and utilize the Gemini model for various use cases.

1.  Check out this repository.\
`git clone https://github.com/muniz/generative-ai-dotnet`

1.  [Obtain an API key](https://makersuite.google.com/app/apikey) to use with the Google AI SDKs.

1.  Open and build the solution(.sln) file of this repo. 

1.  Paste your API key into the `YOUR_API_KEY` property in the `Program` file.

1.  Run the app, put a your text input in console and click enter.

https://github.com/MUN1Z/generative-ai-dotnet/assets/17263249/2e9bc946-de08-4469-a255-eac03005a0e4

## Documentation

Find complete documentation for the Google AI SDKs and the Gemini model in the Google documentation:\
https://ai.google.dev/docs
