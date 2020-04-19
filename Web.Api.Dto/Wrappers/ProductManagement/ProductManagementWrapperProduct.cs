using AutoMapper;
using System;
using System.Collections.Generic;
using Web.Api.Dto.Model.ProductManager;
using Web.Infrastructure;
using Web.ProductManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Services.Interface;
using Web.Api.Dto.Mapper;
using System.Threading.Tasks;
using Web.Services.Exceptions;
using Web.Infrastructure.Exceptions;

namespace Web.Api.Dto.Wrappers.ProductManagement
{
    public class ProductManagementWrapperProduct : ProductManagementWrapper<Product, ProductDto>
    {
        private readonly IMapper _dtoMapper;
        public ProductManagementWrapperProduct(IProductManagementService productManagementService,
            IUrlHelper url,
            HttpRequest request,
            HttpResponse response,
            ILogger logger)
            : base(productManagementService, url, request, response, logger)
        {
            _dtoMapper = new MapperConfig().Mapper;
        }

        public override async Task<ProductDto> Create(Product entity)
        {
            try
            {
                return await Task.Run(() =>
                {
                    ProductManagementService.CreateProduct(entity);
                    if (ProductManagementService.HasErrors())
                    {
                        throw new BusinessException(ProductManagementService.ServiceErrorMessage());
                    }
                    return WrapItem(entity);
                });
            }
            catch (Exception ex)
            {
                throw new InternalException("Error retrieving item", ex);
            }
        }

        public override async Task<ProductDto> GetById(string id)
        {
            try
            {
                return WrapItem(await Task.Run(() => ProductManagementService.GetProduct(id)));
            }
            catch (NotFoundException ex)
            {
                throw new BusinessException("Error retrieving item", ex);
            }
            catch (Exception ex)
            {
                throw new InternalException("Error retrieving item", ex);
            }
        }

        public override async Task<ProductDto> Update(Product entity, string id)
        {
            try
            {
                if (entity.id != id)
                    throw new BusinessException("id must be the same in request and payload");
                return await Task.Run(() =>
                {
                    ProductManagementService.UpdateProduct(id, entity);
                    if (ProductManagementService.HasErrors())
                    {
                        throw new BusinessException(ProductManagementService.ServiceErrorMessage());
                    }
                    return WrapItem(entity);
                });
            }
            catch (NotFoundException ex)
            {
                throw new BusinessException("Error retrieving item", ex);
            }
            catch (Exception ex)
            {
                throw new InternalException("Error retrieving item", ex);
            }
        }

        internal override async Task<IEnumerable<Product>> Get(Filter filter)
        {
            return await ProductManagementService.FindProducts(filter);
        }

        internal override ProductDto GetDtoObject(Product item)
        {
            return _dtoMapper.Map<ProductDto>(item);
        }

        internal override int GetTotalRecords()
        {
            return ProductManagementService.GetTotalProducts();
        }

        internal override string ItemKeyToString(Product item)
        {
            return item.id.ToString();
        }

        internal override List<Link> ItemLinks(ProductDto dtoItem)
        {
            return dtoItem.Links;
        }

        internal override string Title()
        {
            return "Products Wrapper";
        }
    }
}
