using BGL.BusinessModels;
using BGL.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGL.GithubUserManager
{
    public class RepoService : IRepoService
    {
        private readonly IGithubApiRepository apiRepo;

        public RepoService()
        {
            apiRepo = new GithubApiV3Repository();
        }

        public async Task<IEnumerable<Repo>> GetByUsernameAsync(string username)
        {
            try
            {
                var githubRepos = await apiRepo.GetRepos(username);
                List<Repo> repos = new List<Repo>();


                foreach (var repo in githubRepos)
                {
                    Repo r = new Repo()
                    {
                        Name = repo.Name,
                        Description = repo.Description,
                        Url = repo.Html_url,
                        StargazerCount = repo.Stargazers_count
                    };

                    repos.Add(r);
                }

                return repos;
            }
            catch (System.Exception)
            {
                return new List<Repo>();
            }
        }

        public async Task<IEnumerable<Repo>> GetTop5ReposByUsernameOrderByStargazerCountAsync(string username)
        {
            var repos = await GetByUsernameAsync(username);
            return repos.OrderByDescending(r => r.StargazerCount).Take(5);
        }
    }
}

