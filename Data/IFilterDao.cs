using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Filter data access object interface
    /// </summary>
    public interface IFilterDao<T, IdT> : IGenericDao<T, IdT>
    {
        ///// <summary>
        ///// List entities by filter
        ///// </summary>
        ///// <param name="filterText">String for filter</param>
        ///// <returns>A list of filtered entities</returns>
        //IList<T> ListByFilter(string filterText);

        ///// <summary>
        ///// List entities by filter for pagination
        ///// </summary>
        ///// <param name="filterText">String for filter</param>
        ///// <param name="offset">Start record position.</param>
        ///// <param name="limit">Number record.</param>
        ///// <returns>A list of filtered entities</returns>
        //IList<T> ListByFilter(string filterText, int offset, int limit);

        ///// <summary>
        ///// Count number filtered entities.
        ///// </summary>
        ///// <param name="filterText">String for filter</param>
        ///// <returns>Number filtered entities</returns>
        //int CountByFilter(string filterText);
    }
}
