using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.WebServerProxy.Impl
{
    public class ResidentsService : IResidentsService
    {
        public string ServerUrl
        {
            get { return "http://localhost:16434/"; }
        }

        public async Task<IEnumerable<ResidentDTO>> GetAllResidents()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<ResidentDTO>>(
                    await httpClient.GetStringAsync(ServerUrl + "api/Residents")
                );
            }
        }
    }
}
