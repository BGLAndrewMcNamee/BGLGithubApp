using System.Collections.Generic;

namespace BGL.PresentationModels
{
    public class GithubUser
    {
        public string Username { get; set; }
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<GithubRepo> Repos { get; set; }
    }
}