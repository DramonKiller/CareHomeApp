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

        public async Task<IEnumerable<ResidentDTO>> GetResidents(int pageSize, int pageIndex)
        {
            var args = new { pageSize = pageSize, pageIndex = pageIndex };

            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<ResidentDTO>>(
                    await httpClient.GetStringAsync(ServerUrl + "api/Residents?pageIndex=" + pageIndex + "&pageSize=" + pageSize)
                );
            }
        }

        public async Task<int> GetResidentCount()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(ServerUrl + "api/Residents/Count");
                return int.Parse(result);
            }
        }

            
    }
}
