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
    public class ProductController : ControllerBase
    {
        private readonly IProductManagementService _businessService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductManagementService businessService,
            ILogger<ProductController> logger)
        {
            _businessService = businessService;
            _logger = logger;
        }

        [JsonConfigFilter]
        [HttpGet]
        public async Task<ActionResult<PagedCollectionResponseDto<ProductDto>>> Get([FromQuery] Filter filter)
        {
            var result = (await new ProductManagementWrapperProduct
                (_businessService, Url, Request, Response, _logger).WrapCollection(filter));

            return Ok(result);
        }

        [JsonConfigFilter]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            var brand = await new ProductManagementWrapperProduct
                (_businessService, Url, Request, Response, _logger).GetById(id);
            return Ok(brand);
        }
    }
}
