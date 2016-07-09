using PagedList;
using System.Collections.Generic;

namespace Dramonkiller.CareHomeApp.WebClient.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IPagedList ToPagedList<T>(this IEnumerable<T> subsetList, int pageNumber, int pageSize, int totalItemCount)
        {
            return new MyPagedList<T>(subsetList, pageNumber, pageSize, totalItemCount); 
        } 
    }
}