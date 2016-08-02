using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.WebServerProxy
{
    public interface IResidentsService
    {
        Task<IEnumerable<ResidentDTO>> GetAllResidentsAsync();

        Task<IEnumerable<ResidentLiteDTO>> GetAllResidentsLiteAsync();

        Task<IEnumerable<ResidentDTO>> GetResidentsAsync(int pageSize, int pageIndex);

        Task<IEnumerable<ResidentDTO>> GetResidentsAsync(int pageSize, int pageIndex, GetResidentsFiltersDTO filters);

        Task<IEnumerable<ResidentLiteDTO>> GetResidentsLiteAsync(int pageSize, int pageIndex);

        Task<IEnumerable<ResidentLiteDTO>> GetResidentsLiteAsync(int pageSize, int pageIndex, GetResidentsFiltersDTO filters);

        Task<int> GetResidentCountAsync();

        Task<int> GetResidentCountAsync(GetResidentsFiltersDTO filter);

        Task<ResidentDTO> FindAsync(int residentId);
    }
}
