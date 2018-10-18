using System.Collections.Generic;

namespace BGL.BusinessModels
{
    public class User
    {
        public string Username { get; set; }
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<Repo> Repos { get; set; }
    }
}
