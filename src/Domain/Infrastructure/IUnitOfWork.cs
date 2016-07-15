using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using System;
using System.Threading.Tasks;

namespace Dramonkiller.CareHomeApp.Domain.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityBaseRepository<Resident> Residents
        {
            get;
        }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
