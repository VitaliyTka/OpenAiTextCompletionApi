using OpenAiTextCompletionApi.Models;
using OpenAiTextCompletionApi.Data;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace OpenAiTextCompletionApi.Services
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ChatOptions _options = new ChatOptions();


        public async Task<Message> CreateChatCompletion(List<Message> messages)
        {
            var request = new { model = _options.GtpModel, messages = messages.ToArray() };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);

            var response = await _httpClient.PostAsJsonAsync(_options.ApiUrl, request);
            response.EnsureSuccessStatusCode();

            var chatCompletionResponse = await response.Content.ReadFromJsonAsync<ChatbotResponse>();
            return chatCompletionResponse?.choices.First().message;
        }
    }
}
