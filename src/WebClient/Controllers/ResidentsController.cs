using Dramonkiller.CareHomeApp.WebClient.Extensions;
using Dramonkiller.CareHomeApp.WebClient.Models;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using Dramonkiller.CareHomeApp.WebServerProxy;
using Dramonkiller.CareHomeApp.WebServerProxy.Impl;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dramonkiller.CareHomeApp.WebClient.Controllers
{
    public class ResidentsController : Controller
    {
        private IResidentsService residentService;

        public ResidentsController(IResidentsService residentService)
        {
            this.residentService = residentService;
        }

        // GET: Residents
        public async Task<ActionResult> Index(string viewMode, string filterCode, string filterName, int? pageIndex)
        {
            const int pageSize = 18;

            IResidentsService client = new ResidentsService();
            IEnumerable<ResidentDTO> residents;
            int count;
            pageIndex = pageIndex ?? 1;
            GetResidentsFiltersDTO filtersDTO = new GetResidentsFiltersDTO()
            {
                Code = filterCode,
                Name = filterName
            };

            residents = await client.GetResidentsAsync(pageSize, pageIndex.Value, filtersDTO);
            count = await client.GetResidentCountAsync(filtersDTO);

            List<string> filters = new List<string>();

            // TODO: Get the attribute display for the properties
            if (!string.IsNullOrEmpty(filterCode))
            {
                filters.Add(string.Format("Code: '{0}'", filterCode)); 
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                filters.Add(string.Format("Name: '{0}'", filterName));
            }

            ViewBag.ViewMode = viewMode;
            ViewBag.FilterName = filterName;
            ViewBag.FilterCode = filterCode;
            ViewBag.PageIndex = pageIndex;
            ViewBag.FilterString = string.Join("; ", filters); 

            return View(residents.Select(r => ConvertResidentToViewModel(r)).ToPagedList(pageIndex.Value, pageSize, count));
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ResidentDTO resident = await residentService.FindAsync(id.Value);

            if (resident == null)
            {
                return HttpNotFound();
            }

            return View(ConvertResidentToViewModel(resident));
        }

        private ResidentViewModel ConvertResidentToViewModel(ResidentDTO resident)
        {
            if (resident == null)
            {
                return null;
            }

            ResidentViewModel residentViewModel = 
                new ResidentViewModel()
                {
                    Id = resident.Id,
                    Code = resident.Code, 
                    Name = resident.Name,
                    Middle = resident.Middle,
                    Surname = resident.Surname,
                };

            residentViewModel.RefreshFullName();

            return residentViewModel;
        }
    }
}