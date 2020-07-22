using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.ProductManager.Interface;
using Web.ProductManager.Model;

namespace Web.WebApi.Test.Helpers
{
    class TestRepo : IProductManagerData
    {
        public Task<Brand> CreateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> GetBrand(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(string id)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
