using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dramonkiller.CareHomeApp.WebClient.Extensions
{
    public class MyPagedList<T> : IPagedList<T>
    {
        private T[] subsetlist;

        private int pageSize;

        private int pageNumber;

        private int pageCount;

        private int totalItemCount;

        public MyPagedList(IEnumerable<T> subsetlist,  int pageNumber, int pageSize,int totalItemCount)
        {
            this.subsetlist = subsetlist.ToArray();
            this.pageSize = pageSize;
            this.pageNumber = pageNumber;
            this.pageCount = (int)Math.Ceiling(((decimal)totalItemCount / pageSize));
            this.totalItemCount = totalItemCount;  
        }

        public T this[int index]
        {
            get
            {
                return subsetlist[index];
            }
        }

        public int Count
        {
            get
            {
                return subsetlist.Length;
            }
        }

        public int FirstItemOnPage
        {
            get
            {
                return pageSize * pageNumber;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return pageNumber < pageCount;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return pageNumber > 1;
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return pageNumber == 1;
            }
        }

        public bool IsLastPage
        {
            get
            {
                return pageNumber == pageCount;
            }
        }

        public int LastItemOnPage
        {
            get
            {
                return (pageNumber - 1) * pageCount + subsetlist.Length;
            }
        }

        public int PageCount
        {
            get
            {
                return pageCount;
            }
        }

        public int PageNumber
        {
            get
            {
                return pageNumber; 
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize; 
            }
        }

        public int TotalItemCount
        {
            get
            {
                return totalItemCount;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return subsetlist.AsEnumerable().GetEnumerator(); 
        }

        public IPagedList GetMetaData()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return subsetlist.GetEnumerator();
        }
    }
}