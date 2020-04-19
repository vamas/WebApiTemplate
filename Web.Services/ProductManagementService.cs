using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Web.Infrastructure;
using Web.Infrastructure.ActionRunner;
using Web.Infrastructure.BusinessLogic.Interface;
using Web.Infrastructure.BusinessLogic.Model;
using Web.ProductManager.Interface;
using Web.ProductManager.Model;
using Web.Services.Interface;

namespace Web.Services
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly Runner<BusinessLogicEntity, BusinessLogicEntity> _runner;
        private readonly IProductManagerData _productManagementData;

        public IImmutableList<ValidationResult> Errors => _runner.Errors;

        public ProductManagementService(IProductManagerData productManagementData)
        {
            _productManagementData = productManagementData;
            _runner = new Runner<BusinessLogicEntity, BusinessLogicEntity>(_productManagementData);            
        }

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

        public Task<IEnumerable<Brand>> FindBrands(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FindProduct(Filter filter)
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

        public Task<Brand> UpdateBrand(string id, Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(string id, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FindProducts(Filter filter)
        {
            throw new NotImplementedException();
        }

        public int GetTotalProducts()
        {
            throw new NotImplementedException();
        }

        public int GetTotalBrands()
        {
            throw new NotImplementedException();
        }

        public bool HasErrors()
        {
            throw new NotImplementedException();
        }

        public string ServiceErrorMessage()
        {
            throw new NotImplementedException();
        }
    }
}
