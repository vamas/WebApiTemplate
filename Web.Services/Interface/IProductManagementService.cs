using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure;
using Web.ProductManager.Model;

namespace Web.Services.Interface
{
    public interface IProductManagementService
    {
        Task<Brand> CreateBrand(Brand brand);
        Task<Product> CreateProduct(Product product);
        Task DeleteBrand(Brand brand);
        Task DeleteProduct(Product product);
        Task<Brand> UpdateBrand(string id, Brand brand);
        Task<Product> UpdateProduct(string id, Product product);
        Task<Brand> GetBrand(string id);
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Brand>> FindBrands(Filter filter);
        Task<IEnumerable<Product>> FindProducts(Filter filter);
        int GetTotalProducts();
        int GetTotalBrands();
        bool HasErrors();
        string ServiceErrorMessage();
    }
}
