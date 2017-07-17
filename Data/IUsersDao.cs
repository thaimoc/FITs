using Data.DTO;
using System;

namespace Data
{
    /// <summary>
    /// User data access object interface
    /// </summary>
    public interface IUsersDao : IFilterDao<UsersDO, int>
    {
        /// <summary>
        /// Get a user by user name.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <returns>User entity.</returns>
        UsersDO GetByUserName(string userName);

        /// <summary>
        /// Check a user exist
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="id">User identify.</param>
        /// <returns>Boolean.</returns>
        bool UserExist(string userName, int id);

        /// <summary>
        /// Login User Check User name and Password.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">password.</param>
        /// <returns>bool Is Login.</returns>
        bool Login(string userName, string password);

    }
}
