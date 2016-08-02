using AutoMapper;
using Dramonkiller.CareHomeApp.DataAccess.Repositories;
using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using Dramonkiller.CareHomeApp.Domain.Infrastructure;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Dramonkiller.CareHomeApp.WebServer.Controllers
{
    [RoutePrefix("api/residents")]
    public class ResidentsController : ApiController
    {
        private IUnitOfWork unitOfWork;

        private IMapper mapper;

        public ResidentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #region GET
        
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<ResidentDTO>> GetResidents()
        {
            IEnumerable<Resident> residents = await unitOfWork.Residents.GetAll().ToArrayAsync();
             
            return residents.Select(r => mapper.Map<ResidentDTO>(r));
        }

        [Route("lite")]
        [HttpGet]
        public async Task<IEnumerable<ResidentLiteDTO>> GetResidentsLite()
        {
            IEnumerable<Resident> residents = await unitOfWork.Residents.GetAll().ToArrayAsync();

            return residents.Select(r => mapper.Map<ResidentLiteDTO>(r));
        }

        [Route("count")]
        [HttpGet]
        public async Task<int> GetResidentCount([FromUri]GetResidentsFiltersDTO filters = null)
        {
            var query = GetResidentQuery(filters);

            return await query.CountAsync();
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<ResidentDTO>> GetResidents(int pageSize, int pageIndex, [FromUri]GetResidentsFiltersDTO filters = null)
        {
            var query = GetResidentQuery(filters);

            IEnumerable<Resident> residents = await query.OrderBy(r => r.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArrayAsync();

            return residents.Select(r => mapper.Map<ResidentDTO>(r));
        }

        [Route("lite")]
        [HttpGet]
        public async Task<IEnumerable<ResidentLiteDTO>> GetResidentsLite(int pageSize, int pageIndex, [FromUri]GetResidentsFiltersDTO filters = null)
        {
            var query = GetResidentQuery(filters);

            IEnumerable<Resident> residents = await query.OrderBy(r => r.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArrayAsync();

            return residents.Select(r => mapper.Map<ResidentLiteDTO>(r));
        }

        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(ResidentDTO))]
        public async Task<IHttpActionResult> GetResident(int id)
        {
            Resident resident = await unitOfWork.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ResidentDTO>(resident));
        }

        [Route("{id:int}/photo")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetResidentPhoto(int id)
        {
            Resident resident = await unitOfWork.Residents.FindAsync(id);

            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident.PhotoData != null ? Convert.ToBase64String(resident.PhotoData.Photo) : null);
        }

        #endregion

        // PUT: api/Residents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResident(int id, Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resident.Id)
            {
                return BadRequest();
            }

            unitOfWork.Residents.Update(resident); 

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (!ResidentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Residents
        [ResponseType(typeof(Resident))]
        public async Task<IHttpActionResult> PostResident(Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Residents.Add(resident);

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResidentExists(resident.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = resident.Id }, resident);
        }

        // DELETE: api/Residents/5
        [ResponseType(typeof(Resident))]
        public async Task<IHttpActionResult> DeleteResident(int id)
        {
            Resident resident = await unitOfWork.Residents.FindAsync(id);

            if (resident == null)
            {
                return NotFound();
            }

            unitOfWork.Residents.Remove(resident);
            await unitOfWork.SaveChangesAsync();
            
            return Ok(resident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }

            base.Dispose(disposing);
        }

        private IQueryable<Resident> GetResidentQuery(GetResidentsFiltersDTO filters)
        {
            var filterExpression = PredicateBuilder.True<Resident>();

            if (filters != null)
            {
                if (!string.IsNullOrEmpty(filters.Code))
                {
                    filterExpression = filterExpression.And(r => r.Code.Contains(filters.Code));
                }

                if (!string.IsNullOrEmpty(filters.Name))
                {
                    filterExpression = filterExpression.And(r => r.FullName.Contains(filters.Name));
                }
            }

            return unitOfWork.Residents.GetAll().Where(filterExpression).AsExpandable();
        }

        private bool ResidentExists(int id)
        {
            return unitOfWork.Residents.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
