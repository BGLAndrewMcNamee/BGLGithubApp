using BGL.BusinessModels;
using System.Threading.Tasks;

namespace BGL.GithubUserManager
{
    public interface IUserService
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
