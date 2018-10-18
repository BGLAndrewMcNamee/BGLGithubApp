using BGL.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Repository
{
    public class GithubApiV3Repository : IGithubApiRepository
    {
        public async Task<GithubUser> GetUser(string id)
        {
            try
            {
                string json = await GithubApiGetRequestAsync("users/" + id);
                GithubUser user = JsonConvert.DeserializeObject<GithubUser>(json);

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GithubRepo>> GetRepos(string id)
        {
            try
            {
                string json = await GithubApiGetRequestAsync(string.Format("users/{0}/repos", id));
                List<GithubRepo> repos = JsonConvert.DeserializeObject<List<GithubRepo>>(json);

                return repos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> GithubApiGetRequestAsync(string requestUrl)
        {
            string baseGithubApiUrl = "http://api.github.com/";

            using (HttpClient client = new HttpClient())
            {
                string apiUsername = ConfigurationManager.AppSettings["githubApiUsername"].ToString();
                string apiPassword = ConfigurationManager.AppSettings["githubApiPassword"].ToString();
                string authHeaderCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiUsername + ":" + apiPassword));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "Basic " + authHeaderCredentials);

                client.DefaultRequestHeaders.Add("User-Agent", "BGL_Application Webapp");
                
                using (HttpResponseMessage response = await client.GetAsync(baseGithubApiUrl + requestUrl))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();

                    return result;
                }
            }
        }
    }
}
