using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using Dramonkiller.CareHomeApp.Domain.Infrastructure;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public DatabaseContext context;

        public UnitOfWork()
        {
            context = new DatabaseContext();
        }

        private IEntityBaseRepository<Resident> residents;

        public IEntityBaseRepository<Resident> Residents
        {
            get
            {
                if (residents == null)
                {
                    residents = new EntityBaseRepository<Resident>(context);
                }

                return residents;
            }
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new UpdateConcurrencyException(ex);
            }
        }

        public Task SaveChangesAsync()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new UpdateConcurrencyException(ex);
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
