namespace Bayer.MyBayer.WebApi.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GrowerDbContext : DbContext, IDbContext
    {
        public GrowerDbContext() : base("name=Grower") { }
        public GrowerDbContext(string connectionString) : base(connectionString) { }
    }
}