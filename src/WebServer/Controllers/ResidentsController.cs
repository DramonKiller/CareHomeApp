using Dramonkiller.CareHomeApp.DataAccess.Repositories;
using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using Dramonkiller.CareHomeApp.Domain.Infrastructure;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;
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

        public ResidentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region GET
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ResidentDTO>> GetResidents()
        {
            IEnumerable<Resident> residents = await unitOfWork.Residents.GetAll().ToArrayAsync();
             
            return residents.Select(r => ConvertResidentToDTO(r));
        }

        [HttpGet]
        [Route("count")]
        public async Task<int> GetResidentCount()
        {
            return await unitOfWork.Residents.CountAsync();
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ResidentDTO>> GetResidents(int pageSize, int pageIndex)
        {
            IEnumerable<Resident> residents = await unitOfWork.Residents.GetAll().OrderBy(r => r.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArrayAsync();

            return residents.Select(r => ConvertResidentToDTO(r));
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(ResidentDTO))]
        public async Task<IHttpActionResult> GetResident(int id)
        {
            Resident resident = await unitOfWork.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(ConvertResidentToDTO(resident));
        }

        [HttpGet]
        [Route("{id:int}/photo")]
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

        private bool ResidentExists(int id)
        {
            return unitOfWork.Residents.GetAll().Count(e => e.Id == id) > 0;
        }

        private ResidentDTO ConvertResidentToDTO(Resident resident)
        {
            return resident == null ?
                null :
                new ResidentDTO()
                {
                    Id = resident.Id,
                    Code = resident.Code, 
                    Name = resident.Name,
                    Middle = resident.Middle,
                    Surname = resident.Surname,
                    Birthdate = resident.Birthdate,
                    Age = resident.Age  
                }; 
        }
    }
}
