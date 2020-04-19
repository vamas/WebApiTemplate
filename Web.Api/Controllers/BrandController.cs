using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Api.Dto;
using Web.Api.Dto.Model.ProductManager;
using Web.Api.Filters;
using Web.Infrastructure;
using Web.Services.Interface;
using Web.Api.Dto.Wrappers.ProductManagement;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IProductManagementService _businessService;
        private readonly ILogger<BrandController> _logger;

        public BrandController(IProductManagementService businessService,
            ILogger<BrandController> logger)
        {
            _businessService = businessService;
            _logger = logger;
        }

        [JsonConfigFilter]
        [HttpGet]
        public async Task<ActionResult<PagedCollectionResponseDto<BrandDto>>> Get([FromQuery] Filter filter)
        {
            var result = (await new ProductManagementWrapperBrand
                (_businessService, Url, Request, Response, _logger).WrapCollection(filter));

            return Ok(result);
        }

        [JsonConfigFilter]
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetById(string id)
        {
            var brand = await new ProductManagementWrapperBrand
                (_businessService, Url, Request, Response, _logger).GetById(id);
            return Ok(brand);
        }
    }
}
