using Dramonkiller.CareHomeApp.WebClient.Models;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using Dramonkiller.CareHomeApp.WebServerProxy;
using Dramonkiller.CareHomeApp.WebServerProxy.Impl;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dramonkiller.CareHomeApp.WebClient.Controllers
{
    public class ResidentsController : Controller
    {
        // GET: Residents
        public async Task<ActionResult> Index()
        {
            IResidentsService client = new ResidentsService();

            var residentsDTO = await client.GetAllResidents();

            return View(residentsDTO.Select(r => ConvertResidentToViewModel(r)));
        }

        private ResidentViewModel ConvertResidentToViewModel(ResidentDTO resident)
        {
            return resident == null ?
                null :
                new ResidentViewModel()
                {
                    Id = resident.Id,
                    Name = resident.Name,
                    Middle = resident.Middle,
                    Surname = resident.Surname
                };
        }
    }
}