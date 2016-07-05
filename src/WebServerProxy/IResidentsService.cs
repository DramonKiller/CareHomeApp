using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.WebServerProxy
{
    public interface IResidentsService
    {
        Task<IEnumerable<ResidentDTO>> GetAllResidents();
    }
}
