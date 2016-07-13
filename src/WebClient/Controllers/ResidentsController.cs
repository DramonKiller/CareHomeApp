using Dramonkiller.CareHomeApp.WebClient.Extensions;
using Dramonkiller.CareHomeApp.WebClient.Models;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using Dramonkiller.CareHomeApp.WebServerProxy;
using Dramonkiller.CareHomeApp.WebServerProxy.Impl;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dramonkiller.CareHomeApp.WebClient.Controllers
{
    public class ResidentsController : Controller
    {
        // GET: Residents
        public async Task<ActionResult> Index(string viewMode, int? pageIndex)
        {
            const int pageSize = 18;

            IResidentsService client = new ResidentsService();
            IEnumerable<ResidentDTO> residents;
            int count;
            pageIndex = pageIndex ?? 1;

            residents = await client.GetResidents(pageSize, pageIndex.Value);
            count = await client.GetResidentCount();

            ViewBag.ViewMode = viewMode;
            ViewBag.PageIndex = pageIndex;

            return View(residents.Select(r => ConvertResidentToViewModel(r)).ToPagedList(pageIndex.Value, pageSize, count));
        }

        private ResidentViewModel ConvertResidentToViewModel(ResidentDTO resident)
        {
            return resident == null ?
                null :
                new ResidentViewModel()
                {
                    Id = resident.Id,
                    Code = resident.Code, 
                    Name = resident.Name,
                    Middle = resident.Middle,
                    Surname = resident.Surname,
                    FullName = string.Format("{0} {1} {2}", resident.Name, resident.Middle, resident.Surname).Trim()
                };
        }
    }
}