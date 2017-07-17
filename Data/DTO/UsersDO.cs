using Data.BaseCore;
using System;

namespace Data.DTO
{
    public class UsersDO : EntityObject<int>
    {
        /// <summary>
        /// User name login
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// Password login
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// Fullname for user
        /// </summary>
        public virtual string FullName { get; set; }
        /// <summary>
        /// Status for user Active
        /// </summary>
        public virtual string Active { get; set; }
    }
}
