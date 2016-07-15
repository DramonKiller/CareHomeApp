using Dramonkiller.CareHomeApp.DataAccess.Properties;
using System;

namespace Dramonkiller.CareHomeApp.DataAccess.Repositories
{
    public class UpdateConcurrencyException : Exception 
    {
        public UpdateConcurrencyException(Exception innerException) : base(Resources.UpdateConcurrencyExceptionMessage, innerException) 
        {

        }
    }
}
