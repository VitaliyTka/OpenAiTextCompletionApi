namespace OpenAiTextCompletionApi.Data
{
    public class ChatOptions
    {
        public string ApiKey { get; set; } = "";
        public string ApiUrl { get; set; } = "https://api.openai.com/v1/completions";
        public string GtpModel { get; set; } = "gpt-3.5-turbo";
    }
}
