using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Octokit;
using ShantiLk.Api.Models.ShantiClasses.Common;
using ShantiLk.Api.Models.SuaiClasses.Answers;
using ShantiLk.Api.Models.SuaiClasses.Task;
using System.Security.Claims;
using System.Security.Policy;

namespace ShantiLk.Api.Controllers
{
    public partial class GitHubController
    {
        private async Task<bool> h_Login(string code)
        {
            var clientId = "083730b90d4a5b16773b";
            var clientSecret = "ad6821b52333eaf91d685df38926e9bd6cf334cd";
            var client = new GitHubClient(new ProductHeaderValue("ShantiLk"));

            var request = new OauthTokenRequest(clientId, clientSecret, code);
            try
            {
                var token = await client.Oauth.CreateAccessToken(request);
                var oldClaims = HttpContext.User.Claims.ToList();
                var claims = new List<Claim>
                {
                     oldClaims[0],
                     oldClaims[1],
                     oldClaims[2],
                     new Claim(ClaimTypes.Webpage, token.AccessToken)
                };
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                HttpContext.SignOutAsync();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        private string h_getToken()
        {
            var claims = HttpContext.User.Claims.Select(x => x.Value).ToList();
            return claims[3];

        }

        private async Task<string> h_GetUrl()
        {
            var clientId = "083730b90d4a5b16773b";
            var clientSecret = "ad6821b52333eaf91d685df38926e9bd6cf334cd";
            var client = new GitHubClient(new ProductHeaderValue("ShantiLk"));

            var request = new OauthLoginRequest(clientId)
            {
                Scopes = { "user", "notifications", "repo"},
                RedirectUri = new Uri("https://localhost:7043/Github/GetCode")
            };

            // NOTE: user must be navigated to this URL
            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);
            return oauthLoginUrl.AbsoluteUri;
        }

        private async Task<List<Repository>> h_GetRepositories()
        {
            var client = new GitHubClient(new ProductHeaderValue("ShantiLk"));
            client.Credentials = new Credentials(h_getToken());
            var repositories = await client.Repository.GetAllForCurrent();
            return repositories.ToList();
        }

        private async Task<bool> h_SyncTasks(int repositoryId, int semesterId)
        {
            var client = new GitHubClient(new ProductHeaderValue("ShantiLk"));
            client.Credentials = new Credentials(h_getToken());

            //Get issues on github
            var issues = await client.Issue.GetAllForRepository(repositoryId);
            List<int> issuesIds = issues.Where(x=>x.Labels.Select(l=>l.Name).Contains("SUAI"))
                .Select(x => Convert.ToInt32(x.Title.Substring(1, x.Title.IndexOf(' ')))).ToList();
            //Get tasks on suai
            SuaiHttpClient suaiclient = new SuaiHttpClient(HttpContext.User);
            suaiclient.AddFormEncoded("iduser", "0");
            HttpResponseMessage resp = new HttpResponseMessage();
            suaiclient.AddFormEncoded("semester", semesterId.ToString());
            resp = suaiclient.Post("https://pro.guap.ru/get-student-tasks/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            List<s_TaskListItem> tasks = JsonConvert.DeserializeObject<s_TaskListAnswer>(result).Tasks;

            //Get new tasks
            List<int> taskIds = tasks.Select(x=>x.Id).ToList();
            List<int> newTaskIds = taskIds.Except(issuesIds).ToList();

            for(int i = 0; i < newTaskIds.Count; i++)
            {
                var newTask = newTaskIds[i];
                s_TaskListItem task = tasks.First(x => x.Id == newTask);
                NewIssue issue = new NewIssue("#" + newTask.ToString() + " " + task.SubjectName + " " + task.Name);
                issue.Body = "Name: " + task.Name + "\n ";
                issue.Body += "Subject: " + task.SubjectName + "\n ";
                issue.Body += "DeadLine: " + task.DeadLine + "\n ";
                issue.Body += "Description: " + task.Description;
                issue.Labels.Add("SUAI");
                await client.Issue.Create(repositoryId, issue);
                if(i % 10 == 0)
                {
                    Thread.Sleep(5000); 
                }
            }

            //Check closed
            if (newTaskIds.Count > -1)
            {
                issues = await client.Issue.GetAllForRepository(repositoryId);
                issuesIds = issues.Where(x => x.Labels.Select(l => l.Name).Contains("SUAI")).Select(x => 
                    Convert.ToInt32(x.Title.Substring(1, x.Title.IndexOf(' ')))).ToList();
            }
            List<int> closedTaskIds = tasks.Where(x => x.StatusId == 2).Select(x => x.Id).ToList();
            List<int> closedIssuesIds = closedTaskIds.Intersect(issuesIds).ToList();
            List<Issue> issueList = issues.Where(x => x.Labels.Select(l => l.Name).Contains("SUAI") &&
                closedIssuesIds.Contains(Convert.ToInt32(x.Title.Substring(1, x.Title.IndexOf(' '))))).ToList();
            for (int i = 0; i < issueList.Count; i++)
            {
                Issue closeIssue = issueList[i];
                await client.Issue.Update(repositoryId, closeIssue.Number,
                    new IssueUpdate
                    {
                        State = ItemState.Closed
                    });
                if (i % 10 == 0)
                {
                    Thread.Sleep(5000);
                }
            }
            return true;
        }
    }
}
