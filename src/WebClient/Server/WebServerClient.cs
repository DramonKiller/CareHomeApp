using Dramonkiller.HappyGrandpaCareHome.WebServerDTOs.Residents;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dramonkiller.HappyGrandpaCareHome.WebClient.Server
{
    public class WebServerClient
    {
        public string ServerUrl
        {
            get { return "http://localhost:16434/api/"; }
        }

        public async Task<IEnumerable<ResidentDTO>> GetAllResidents()
        {
            using (HttpClient httpClient = new HttpClient())
            {

                return JsonConvert.DeserializeObject<List<ResidentDTO>>(
                    await httpClient.GetStringAsync(ServerUrl + "/Residents" )
                );
            }
        }
    }
}