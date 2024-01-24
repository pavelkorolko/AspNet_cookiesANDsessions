using OpenAI_API;

namespace Classwork_12._01._24_cookies_sessions_.API
{
    public class APIGTP
    {
        private readonly string api = "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";
        private readonly OpenAIAPI openAPI;
        public APIGTP() { 
            this.openAPI = new OpenAIAPI(api);
        }
        public List<string> GetResult(string inquiry, string description)
        {
            IList<string> result = new List<string>();

            string redoneInquiry = "Provide description of " + inquiry + " basing on this info " + description + ". Provide text for 300 symbols.";

            var completions = openAPI.Completions.CreateCompletionAsync(
                prompt: redoneInquiry,
                model: "gpt-3.5-turbo-instruct",
                max_tokens: 300,
                temperature: 1f
            );

            foreach (var completion in completions.Result.Completions)
            {
                result.Add(completion.Text);
            }

            return result.ToList();
        }
    }
}
