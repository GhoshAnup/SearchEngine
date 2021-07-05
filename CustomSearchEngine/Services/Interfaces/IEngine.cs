using System.Threading.Tasks;

namespace CustomSearchEngine.Services.Interfaces
{
    public interface IEngine
    {
        string EngineName { get; }
        Task<int[]> GetRankingPosition(string keyword, string searchUrl);
    }
}
