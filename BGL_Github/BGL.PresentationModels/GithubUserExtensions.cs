using BGL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.PresentationModels
{
    public static class GithubUserExtensions
    {
        public static GithubUser ToPresentationModel(this User user)
        {
            return new GithubUser()
            {
                Username = user.Username,
                Repos = user.Repos.ToPresentationModel(),
                AvatarUrl = user.AvatarUrl,
                Location = user.Location
            };
        }
    }
}
