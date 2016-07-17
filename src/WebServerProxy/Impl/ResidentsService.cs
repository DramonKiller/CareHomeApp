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

        public async Task<IEnumerable<ResidentDTO>> GetAllResidentsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<ResidentDTO>>(
                    await httpClient.GetStringAsync(ServerUrl + "api/Residents")
                );
            }
        }

        public async Task<IEnumerable<ResidentDTO>> GetResidentsAsync(int pageSize, int pageIndex)
        {
            return await GetResidentsAsync(pageSize, pageIndex, null);
        }

        public async Task<IEnumerable<ResidentDTO>> GetResidentsAsync(int pageSize, int pageIndex, GetResidentsFiltersDTO filter)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string filterArgs = GetArguments(filter);
                string url = ServerUrl + "api/Residents?pageIndex=" + pageIndex +
                    "&pageSize=" + pageSize +
                    (string.IsNullOrEmpty(filterArgs) ? string.Empty : ("&" + filterArgs));

                return JsonConvert.DeserializeObject<List<ResidentDTO>>(
                    await httpClient.GetStringAsync(url));
            }
        }

        public async Task<int> GetResidentCountAsync()
        {
            return await GetResidentCountAsync(null);
        }

        public async Task<int> GetResidentCountAsync(GetResidentsFiltersDTO filter)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string filterArgs = GetArguments(filter);
                string url = ServerUrl + "api/Residents/Count" + (string.IsNullOrEmpty(filterArgs) ? string.Empty : ("?" + filterArgs));

                string result = await httpClient.GetStringAsync(url);

                return int.Parse(result);
            }
        }

        public async Task<ResidentDTO> FindAsync(int residentId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<ResidentDTO>(await httpClient.GetStringAsync(ServerUrl + "api/Residents/" + residentId));
            }
        }

        private string GetArguments(GetResidentsFiltersDTO filters)
        {
            List<string> args = new List<string>();
            // TODO: Escape & and spaces
            if (!string.IsNullOrEmpty(filters.Code))
            {
                args.Add("Code=" + filters.Code); 
            }

            if (!string.IsNullOrEmpty(filters.Name))
            {
                args.Add("Name=" + filters.Name);
            }

            return string.Join("&", args); 
        }
    }
}
