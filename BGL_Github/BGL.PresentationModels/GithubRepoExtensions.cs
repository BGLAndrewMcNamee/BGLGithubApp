using BGL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BGL.PresentationModels
{
    public static class GithubRepoExtensions
    {
        public static GithubRepo ToPresentationModel(this Repo repo)
        {
            return new GithubRepo()
            {
                Name = repo.Name,
                Description = repo.Description,
                StargazerCount = repo.StargazerCount,
                Url = repo.Url
            };
        }

        public static IEnumerable<GithubRepo> ToPresentationModel(this IEnumerable<Repo> repos)
        {
            List<GithubRepo> newRepos = new List<GithubRepo>();

            foreach (var repo in repos)
            {
                newRepos.Add(repo.ToPresentationModel());
            }
            return newRepos;
        }
    }
}
