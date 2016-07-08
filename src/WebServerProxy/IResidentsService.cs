using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.WebServerProxy
{
    public interface IResidentsService
    {
        Task<IEnumerable<ResidentDTO>> GetAllResidents();
    }
}
