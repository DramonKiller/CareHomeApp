using Dramonkiller.HappyGrandpaCareHome.Core.Extensions;
using Dramonkiller.HappyGrandpaCareHome.Core.Models;
using Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents;
using Dramonkiller.HappyGrandpaCareHome.WebServerDTOs.Residents;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Dramonkiller.HappyGrandpaCareHome.WebServer.Controllers
{
    public class ResidentsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Residents
        public async Task<IEnumerable<ResidentDTO>> GetResidents()
        {
            IEnumerable<Resident> residents = await db.Residents.ToArrayAsync();
             
            return residents.Select(r => ConvertResidentToDTO(r));
        }

        // GET: api/Residents/5
        [ResponseType(typeof(Resident))]
        public async Task<IHttpActionResult> GetResident(int id)
        {
            Resident resident = await db.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

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

            db.Entry(resident).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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

            db.Residents.Add(resident);

            try
            {
                await db.SaveChangesAsync();
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
            Resident resident = await db.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            db.Residents.Remove(resident);
            await db.SaveChangesAsync();

            return Ok(resident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool ResidentExists(int id)
        {
            return db.Residents.Count(e => e.Id == id) > 0;
        }

        private ResidentDTO ConvertResidentToDTO(Resident resident)
        {
            return resident == null ?
                null :
                new ResidentDTO()
                {
                    Id = resident.Id,
                    Name = resident.Name,
                    Middle = resident.Middle,
                    Surname = resident.Surname
                }; 
        }
    }
}
