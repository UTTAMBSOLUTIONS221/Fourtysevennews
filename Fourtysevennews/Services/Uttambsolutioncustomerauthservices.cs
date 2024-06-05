using Newtonsoft.Json;
using System.Text;
using Fourtysevennews.Entities.Auth;
using Fourtysevennews;
using Fourtysevennews.Models.Auth;

namespace Uttambsolutionadmin.Apiservices.Auth
{
    public class Uttambsolutioncustomerauthservices
    {
        string BaseUrl = "";
        public Uttambsolutioncustomerauthservices(IConfiguration config)
        {
            BaseUrl = Util.Currenttenantbaseurlstring(config);
        }
        #region Login User
        public async Task<Customermodelresponce> Validatecustomer(Userloginmodel obj)
        {
            Customermodelresponce userModel = new Customermodelresponce { };
            var resp = await CUSTOMERPOSTTOAPILOGIN("/api/CustomerAuthentication/AuthenticateUttambSolutionCustomer", obj);
            if (resp.RespStatus == 0)
            {
                userModel = new Customermodelresponce
                {
                    Token = resp.Token,
                    Customermodel = resp.Customermodel,
                    RespStatus = resp.RespStatus,
                    RespMessage = resp.RespMessage,
                };
            }
            else
            {
                userModel.RespStatus = 401;
                userModel.RespMessage = "Incorrect Password!";
            }

            return userModel;
        }
        #endregion




        #region Other Methods
        public async Task<Customermodelresponce> CUSTOMERPOSTTOAPILOGIN(string endpoint, dynamic obj)
        {
            Customermodelresponce resp = new Customermodelresponce();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Customermodelresponce>(outPut);
                }
            }
            return resp;
        }
        #endregion
    }
}
