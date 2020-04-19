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
    public class ProductManagementWrapperBrand : ProductManagementWrapper<Brand, BrandDto>
    {
        private readonly IMapper _dtoMapper;
        public ProductManagementWrapperBrand(IProductManagementService productManagementService,
            IUrlHelper url,
            HttpRequest request,
            HttpResponse response,
            ILogger logger)
            : base(productManagementService, url, request, response, logger)
        {
            _dtoMapper = new MapperConfig().Mapper;
        }

        public override async Task<BrandDto> Create(Brand entity)
        {
            try
            {
                return await Task.Run(() =>
                {
                    ProductManagementService.CreateBrand(entity);
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

        public override async Task<BrandDto> GetById(string id)
        {
            try
            {
                return WrapItem(await Task.Run(() => ProductManagementService.GetBrand(id)));
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

        public override async Task<BrandDto> Update(Brand entity, string id)
        {
            try
            {
                if (entity.id != id)
                    throw new BusinessException("id must be the same in request and payload");
                return await Task.Run(() =>
                {
                    ProductManagementService.UpdateBrand(id, entity);
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

        internal override async Task<IEnumerable<Brand>> Get(Filter filter)
        {
            return await ProductManagementService.FindBrands(filter);
        }

        internal override BrandDto GetDtoObject(Brand item)
        {
            return _dtoMapper.Map<BrandDto>(item);
        }

        internal override int GetTotalRecords()
        {
            return ProductManagementService.GetTotalBrands();
        }

        internal override string ItemKeyToString(Brand item)
        {
            return item.id.ToString();
        }

        internal override List<Link> ItemLinks(BrandDto dtoItem)
        {
            return dtoItem.Links;
        }

        internal override string Title()
        {
            return "Brands Wrapper";
        }
    }
}
