using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System;
using Formula.Newsfeed.Services;

namespace Formula.Newsfeed
{
    public static class News
    {
        [FunctionName("Get")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            try
            {
                string uri = Environment.GetEnvironmentVariable("FeedUri");
                NewsfeedServices newsfeedServices = new NewsfeedServices();
                return newsfeedServices.GetItems(uri);
            }
            catch (Exception ex)
            {
                return $"Error:{ex.Message}";
            }
        }
    }
}
