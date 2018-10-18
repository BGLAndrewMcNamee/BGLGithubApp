using BGL.BusinessModels;
using BGL.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGL.GithubUserManager
{
    public class UserService : IUserService
    {
        private readonly IGithubApiRepository apiRepo;


        public UserService()
        {
            apiRepo = new GithubApiV3Repository();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var githubUser = await apiRepo.GetUser(username);
            try
            {
                User user = new User()
                {
                    Username = githubUser.Name,
                    Location = githubUser.Location,
                    AvatarUrl = githubUser.AvatarUrl.ToString(),
                    Repos = new List<Repo>()
                };

                return user;
            }
            catch (System.Exception)
            {
                return new User();
            }
        }
    }
}
