using System;

namespace Data.BaseCore
{
    /// <summary>
    /// Base entity object
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public abstract class EntityObject<IdT> : IDao
    {
        /// <summary>
        /// Id identify
        /// </summary>
        public virtual IdT Id { get; set; }
        /// <summary>
        /// SortOrder
        /// </summary>
        public virtual int SortOrder { get; set; }
        /// <summary>
        /// Created by
        /// </summary>
        public virtual int CreatedById { get; set; }
        /// <summary>
        /// Created time
        /// </summary>
        public virtual DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Updated by
        /// </summary>
        public virtual int UpdatedById { get; set; }
        /// <summary>
        /// Updated Time
        /// </summary>
        public virtual DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Status action only use on form not map db
        /// </summary>
        public virtual string StatusAction { get; set; }
    }
}
