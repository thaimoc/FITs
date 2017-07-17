using Data.BaseCore;
using System;
using System.Collections.Generic;

namespace Data.Factory
{
    /// <summary>
    /// Data access object factory interface
    /// </summary>
    public interface IDaoFactory
    {
        T GetDao<T>() where T : IDao;
    }
}
