using AutoMapper;
using Dramonkiller.CareHomeApp.Utilities.Extensions;
using Dramonkiller.CareHomeApp.WebClient.Extensions;
using Dramonkiller.CareHomeApp.WebClient.ViewModels;
using Dramonkiller.CareHomeApp.WebClient.ViewModels.Residents;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using Dramonkiller.CareHomeApp.WebServerProxy;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dramonkiller.CareHomeApp.WebClient.Controllers
{
    public class ResidentsController : Controller
    {
        public const string ControllerName = "Residents";

        public const string IndexAction = "Index";

        public const string EditAction = "Edit";

        public const string DeleteAction = "Delete";

        private IResidentsService residentService;

        private IMapper mapper;

        public ResidentsController(IResidentsService residentService, IMapper mapper)
        {
            this.residentService = residentService;
            this.mapper = mapper;
        }

        // GET: Residents
        public async Task<ActionResult> Index(string viewMode, string filterCode, string filterName, int? pageIndex)
        {
            const int pageSize = 18;

            IEnumerable<ResidentLiteDTO> residents;
            int count;
            pageIndex = pageIndex ?? 1;
            GetResidentsFiltersDTO filtersDTO = new GetResidentsFiltersDTO()
            {
                Code = filterCode,
                Name = filterName
            };

            count = await residentService.GetResidentCountAsync(filtersDTO);

            if (Math.Floor((decimal)(count / pageSize)) < pageIndex - 1)
            {
                pageIndex = 1;
            }

            residents = await residentService.GetResidentsLiteAsync(pageSize, pageIndex.Value, filtersDTO);

            List<string> filters = new List<string>();

            if (!string.IsNullOrEmpty(filterCode))
            {
                string labelText = AttributeExtensions.GetDisplayName<ResidentViewModel>(MemberExtensions.GetPropertyName<ResidentViewModel>(r => r.Code));
                filters.Add(string.Format("{0}: '{1}'", labelText, filterCode)); 
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                string labelText = AttributeExtensions.GetDisplayName<ResidentViewModel>(MemberExtensions.GetPropertyName<ResidentViewModel>(r => r.FullName));
                filters.Add(string.Format("Name: '{0}'", filterName));
            }

            ResidentIndexViewModel viewModel = new ResidentIndexViewModel
            {
                ViewMode = viewMode,
                FilterName = filterName,
                FilterCode = filterCode,
                PageIndex = pageIndex.Value,
                FilterString = string.Join("; ", filters),
                Residents = residents.Select(r => mapper.Map<ResidentViewModel>(r)).ToPagedList(pageIndex.Value, pageSize, count) as IPagedList<ResidentViewModel>
            };

            return View(viewModel);
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

            return View(mapper.Map<ResidentDTO>(resident));
        }
    }
}