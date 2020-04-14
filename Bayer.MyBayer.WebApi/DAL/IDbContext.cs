using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayer.MyBayer.WebApi.DAL
{
    public interface IDbContext : IDisposable
    {
        Database Database { get;}
        //DbEntityEntry Entry(object entity)

    }
}
