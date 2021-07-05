using CustomSearchEngine.Constants;
using CustomSearchEngine.Services.Interfaces;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace CustomSearchEngine.Services.Google
{
    public class GoogleEngine : IEngine
    {
        private readonly HttpClient _httpClient;
        public GoogleEngine(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string EngineName { get; } = Constant.Google;
        public async Task<int[]> GetRankingPosition(string keywords, string searchUrl)
        {
            var encodedKeywords = HttpUtility.UrlEncode(keywords);
            var response = await _httpClient.GetAsync(string.Format(Constant.GoogleSearchUrl,encodedKeywords));
            var html = await response.Content.ReadAsStringAsync();
            var regex = new Regex(Constant.Regex, RegexOptions.Multiline);
            var matches = regex.Matches(html);
            var results = matches.Select(x => x.Groups[1].Value);
            return results
                .Select((x, i) => (Index: i, IsMatch: x.Equals(searchUrl, StringComparison.OrdinalIgnoreCase)))
                .Where(x => x.IsMatch)
                .Select(x => x.Index + 1)
                .ToArray();
        }
    }
}

