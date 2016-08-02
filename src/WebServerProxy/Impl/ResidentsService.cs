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
                    await httpClient.GetStringAsync(ServerUrl + "api/residents")
                );
            }
        }

        public async Task<IEnumerable<ResidentLiteDTO>> GetAllResidentsLiteAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<ResidentLiteDTO>>(
                    await httpClient.GetStringAsync(ServerUrl + "api/residents/lite")
                );
            }
        }

        public async Task<IEnumerable<ResidentDTO>> GetResidentsAsync(int pageSize, int pageIndex)
        {
            return await GetResidentsAsync(pageSize, pageIndex, null);
        }

        public async Task<IEnumerable<ResidentDTO>> GetResidentsAsync(int pageSize, int pageIndex, GetResidentsFiltersDTO filter)
        {
            return JsonConvert.DeserializeObject<List<ResidentDTO>>(
                await GetCallResidentsAsync(pageSize, pageIndex, filter, false));
        }

        public async Task<IEnumerable<ResidentLiteDTO>> GetResidentsLiteAsync(int pageSize, int pageIndex)
        {
            return await GetResidentsLiteAsync(pageSize, pageIndex, null);
        }

        public async Task<IEnumerable<ResidentLiteDTO>> GetResidentsLiteAsync(int pageSize, int pageIndex, GetResidentsFiltersDTO filter)
        {
            return JsonConvert.DeserializeObject<List<ResidentLiteDTO>>(
                await GetCallResidentsAsync(pageSize, pageIndex, filter, true));
        }

        private async Task<string> GetCallResidentsAsync(int pageSize, int pageIndex, GetResidentsFiltersDTO filter, bool lite)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string filterArgs = GetArguments(filter);
                string url = ServerUrl + "api/residents" + (lite ? "/lite" : string.Empty) + "?pageIndex=" + pageIndex +
                    "&pageSize=" + pageSize +
                    (string.IsNullOrEmpty(filterArgs) ? string.Empty : ("&" + filterArgs));

                return await httpClient.GetStringAsync(url);
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
                string url = ServerUrl + "api/residents/Count" + (string.IsNullOrEmpty(filterArgs) ? string.Empty : ("?" + filterArgs));

                string result = await httpClient.GetStringAsync(url);

                return int.Parse(result);
            }
        }

        public async Task<ResidentDTO> FindAsync(int residentId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<ResidentDTO>(await httpClient.GetStringAsync(ServerUrl + "api/residents/" + residentId));
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
