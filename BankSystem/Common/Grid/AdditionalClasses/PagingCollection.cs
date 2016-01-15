// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagingCollection.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Store information about paged collection
    /// </summary>
    /// <typeparam name="T">Any class</typeparam>
    public class PagingCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Page size
        /// </summary>
        private int pageSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingCollection{T}" /> class.
        /// </summary>
        /// <param name="collection">Base items collection</param>
        /// <param name="totalCount">Total count of entities</param>
        /// <param name="pageSize">Items count per page</param>       
        public PagingCollection(IEnumerable<T> collection, int totalCount, int pageSize = 20)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.TotalCount = totalCount;
            this.PageSize = pageSize;
            this.CurrentPageCollection = collection;
            this.CurrentPage = 1;
        }

        #region properties

        /// <summary>
        /// Base collection
        /// </summary>
        public IEnumerable<T> CurrentPageCollection { get; set; }

        /// <summary>
        /// Gets or sets current page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total entities count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets page size
        /// </summary>
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.pageSize = value;
            }
        }

        /// <summary>
        /// Gets pages count
        /// </summary>
        public int PagesCount
        {
            get
            {
                return (int)Math.Ceiling(this.TotalCount / (decimal)this.PageSize);
            }
        }
        #endregion        

        #region IEnumerable<T> Members
        /// <summary>
        /// Returns an enumerator that iterates through collection
        /// </summary>
        /// <returns>Returns an enumerator that iterates through  collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.CurrentPageCollection.GetEnumerator();
        }
        #endregion

        #region IEnumerable Members
        /// <summary>
        /// Returns an enumerator that iterates through collection
        /// </summary>
        /// <returns>Returns an enumerator that iterates through  collection</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
