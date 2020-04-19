using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Dto = Web.Api.Dto.Model.ProductManager;
using Domain = Web.ProductManager.Model;

namespace Web.Api.Dto.Mapper
{
    public class MapperConfig
    {
        private static IMapper _mapper;
        public MapperConfig() { }

        public IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                    CreateDataMapper();
                return _mapper;
            }
        }

        private void CreateDataMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Dto.Model.ProductManager.BrandDto, Domain.Brand>();
                cfg.CreateMap<Domain.Brand, Dto.Model.ProductManager.BrandDto >();
                cfg.CreateMap<Dto.Model.ProductManager.ProductDto, Domain.Product>();
                cfg.CreateMap<Domain.Product, Dto.Model.ProductManager.ProductDto>();
            }).CreateMapper();
        }
    }
}
