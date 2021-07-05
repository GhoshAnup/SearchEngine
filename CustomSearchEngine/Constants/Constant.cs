namespace CustomSearchEngine.Constants
{
    public static class Constant
    {
        public const string Google = "google";
        public const string Bing = "bing";
        public const string GoogleSearchUrl = "https://google.com/search?num=100&q={0}&btnG=Search";
        public const string Regex = @"\<h3[\s\S]*?\<\/h3\>[\n\s]*\<div[\s\S]*?\>[\n\s]*([\S]*?)[ \<]";
    }
}
