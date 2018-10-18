using BGL.BusinessModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGL.GithubUserManager
{
    public interface IRepoService
    {
        Task<IEnumerable<Repo>> GetByUsernameAsync(string username);
        Task<IEnumerable<Repo>> GetTop5ReposByUsernameOrderByStargazerCountAsync(string username);
    }
}
