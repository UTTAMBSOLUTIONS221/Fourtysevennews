using Fourtysevennews.Models.Blogs;
using Newtonsoft.Json;

namespace Fourtysevennews.Services
{
    public class Fourtysevennewsservices
    {
        string BaseUrl = "";
        public Fourtysevennewsservices(IConfiguration config)
        {
            BaseUrl = Util.Currenttenantbaseurlstring(config);
        }
        public async Task<SystemblognewsDetail> GetSystemfortysevennewsblogdata(int Page, int PageSize, string? Category)
        {
            SystemblognewsDetail obj = new SystemblognewsDetail();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/BlogNewsManagement/Getsystemblognewsdata?Page=" + Page + "&PageSize=" + PageSize + "&Category=" + Category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<SystemblognewsDetail>(apiResponse);
                }
            }
            return obj;
        }
        public async Task<Fortysevennewsblogsdata> Getsystemfortysevennewsblogdetaildatabyid(long BlogId)
        {
            Fortysevennewsblogsdata obj = new Fortysevennewsblogsdata();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/BlogNewsManagement/Getsystemhomefortysevennewsblogdetaildatabyid/" + BlogId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<Fortysevennewsblogsdata>(apiResponse);
                }
            }
            return obj;
        }
    }
}
