using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.BusinessLogic.Interface;
using Web.ProductManager.Interface;
using Web.ProductManager.Model;

namespace Web.ProductManager.Data
{
    public class ProductManagerData : IProductManagerData
    {
        private static Hashtable _brands = new Hashtable();
        private static Hashtable _products = new Hashtable();
        
        public ProductManagerData()
        {
        }

        public async Task DeleteProduct(Product product)
        {
            await Task.Run(() =>
            {
                if (_products.Contains(product.id))
                {
                    _products.Remove(product.id);
                }
                return null;
            });
        }

        public async Task DeleteBrand(Brand brand)
        {
            await Task.Run(() =>
            {
                if (_brands.Contains(brand.id))
                {
                    _brands.Remove(brand.id);
                }
                return null;
            });
        }

        public async Task<Brand> GetBrand(string id)
        {
            var task = await Task.Run(() =>
            {
                if (_brands.Contains(id))
                {
                    var brand = _brands[id] as Brand;
                    brand.products = _products.Values.OfType<Product>().ToList()
                        .Where(x => x.brandId == id).ToList();
                    return brand;
                }
                return null;
            });
            return task;
        }

        public async Task<Product> GetProduct(string id)
        {
            var task = await Task.Run(() =>
            {
                if (_products.Contains(id))
                {
                    return _products[id] as Product;
                }
                return null;
            });
            return task;
        }


        public async Task<Product> CreateProduct(Product product)
        {
            var task = await Task.Run(() =>
            {
                if (!_products.Contains(product.id))
                {
                    _products[product.id] = product;
                    return _products[product.id] as Product;
                }
                return null;
            });
            return task;
        }

        public async Task<Brand> CreateBrand(Brand brand)
        {
            var task = await Task.Run(() =>
            {
                if (!_brands.Contains(brand.id))
                {
                    _brands[brand.id] = brand;
                    return _brands[brand.id] as Brand;
                }
                return null;
            });
            return task;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
