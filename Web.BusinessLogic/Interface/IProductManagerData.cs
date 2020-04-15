using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.BusinessLogic.Interface;
using Web.ProductManager.Model;

namespace Web.ProductManager.Interface
{
    public interface IProductManagerData : IBusinessLogicData
    {
        Task<Brand> CreateBrand(Brand brand);
        Task<Product> CreateProduct(Product product);
        Task DeleteProduct(Product product);
        Task DeleteBrand(Brand brand);
        Task<Brand> GetBrand(string id);
        Task<Product> GetProduct(string id);
    }
}
