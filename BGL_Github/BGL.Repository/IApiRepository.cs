using BGL.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGL.Repository
{
    public interface IGithubApiRepository
    {
        Task<GithubUser> GetUser(string id);
        Task<IEnumerable<GithubRepo>> GetRepos(string id);
    }
}
